using ExpenseManager.DatabaseModels;
using MongoDB.Driver;
using System.Windows;

namespace ExpenseManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "mongodb://127.0.0.1:27017";
        private const string DatabaseName = "ExpenseManagerDB";
        private const string UsersCollectionName = "Users";
        private const string RecordsCollectionName = "Records";
        private IMongoDatabase Database;
        private IMongoCollection<User> UsersCollection;
        private IMongoCollection<Record> RecordsCollection;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDatabase();
            InitializeCollections();
            View.Content = new HomePage(this, UsersCollection, RecordsCollection);
        }

        private void InitializeDatabase()
        {
            var mongoClient = new MongoClient(ConnectionString);
            Database = mongoClient.GetDatabase(DatabaseName);
        }

        private void InitializeCollections()
        {
            UsersCollection = Database.GetCollection<User>(UsersCollectionName);
            RecordsCollection = Database.GetCollection<Record>(RecordsCollectionName);
        }
    }
}
