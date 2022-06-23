using ExpenseManager.DatabaseModels;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    }
}
