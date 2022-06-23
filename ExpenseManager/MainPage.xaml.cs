using ExpenseManager.DatabaseModels;
using MongoDB.Driver;
using System.Windows;
using System.Windows.Controls;

namespace ExpenseManager
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly MainWindow MainWindow;
        private readonly User SignedInUser;
        private readonly IMongoCollection<Record> RecordsCollection;

        public MainPage(MainWindow mainWindow, User signedInUser, IMongoCollection<Record> recordsCollection)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            SignedInUser = signedInUser;
            RecordsCollection = recordsCollection;
        }

        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new NewExpenseForm(SignedInUser, RecordsCollection)
            {
                Owner = MainWindow
            };
            dialog.ShowDialog();
        }
    }
}
