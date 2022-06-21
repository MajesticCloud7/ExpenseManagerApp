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
        private readonly IMongoDatabase Database;
        private IMongoCollection<User> UsersCollection;

        public MainWindow()
        {
            InitializeComponent();
            var mongoClient = new MongoClient(ConnectionString);
            Database = mongoClient.GetDatabase(DatabaseName);
            UsersCollection = Database.GetCollection<User>("Users");
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SignUpForm(UsersCollection)
            {
                Owner = this
            };
            dialog.ShowDialog();
        }
    }
}
