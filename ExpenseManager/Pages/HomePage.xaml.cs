using ExpenseManager.DatabaseModels;
using ExpenseManager.Forms;
using MongoDB.Driver;
using System.Windows;
using System.Windows.Controls;

namespace ExpenseManager.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private readonly MainWindow MainWindow;
        private readonly IMongoCollection<User> UsersCollection;
        private readonly IMongoCollection<Record> RecordsCollection;

        public HomePage(MainWindow mainWindow, IMongoCollection<User> usersCollection, IMongoCollection<Record> recordsCollection)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            UsersCollection = usersCollection;
            RecordsCollection = recordsCollection;
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SignUpForm(UsersCollection)
            {
                Owner = MainWindow
            };
            dialog.ShowDialog();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SignInForm(UsersCollection)
            {
                Owner = MainWindow
            };
            if (dialog.ShowDialog() == true)
            {
                MainWindow.View.Content = new MainPage(MainWindow, dialog.SignedInUser, RecordsCollection);
            }
        }
    }
}
