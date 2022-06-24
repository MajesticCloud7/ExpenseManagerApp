using ExpenseManager.DatabaseModels;
using ExpenseManager.Forms;
using MongoDB.Driver;
using System.Windows;
using System.Windows.Controls;

namespace ExpenseManager.Pages
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
            var signedInUserExpenses = RecordsCollection.Find(r => r.UserId == signedInUser.Id && r.RecordType == RecordType.Expense);
            signedInUserExpenses.ToList().ForEach(i => RecordsTable.Items.Add(i));
        }

        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new NewExpenseForm(SignedInUser, RecordsCollection)
            {
                Owner = MainWindow
            };
            if (dialog.ShowDialog() == true)
            {
                RecordsTable.Items.Add(dialog.NewExpense);
            }
        }

        private void EditExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            var expense = (Record)RecordsTable.SelectedItem;
            if (expense is not null)
            {
                var dialog = new EditExpenseForm(expense, RecordsCollection)
                {
                    Owner = MainWindow
                };
                dialog.ShowDialog();
            }
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GoToHomePage();
        }
    }
}
