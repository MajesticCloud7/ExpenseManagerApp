using ExpenseManager.DatabaseModels;
using MongoDB.Driver;
using System.Windows;

namespace ExpenseManager
{
    /// <summary>
    /// Interaction logic for NewExpenseForm.xaml
    /// </summary>
    public partial class NewExpenseForm : Window
    {
        private readonly User RecordOwner;
        private readonly IMongoCollection<Record> RecordsCollection;

        public NewExpenseForm(User recordOwner, IMongoCollection<Record> recordsCollection)
        {
            InitializeComponent();
            RecordOwner = recordOwner;
            RecordsCollection = recordsCollection;
            AmountBox.Focus();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var amountString = AmountBox.Text;
            var description = DescriptionBox.Text;

            if (double.TryParse(amountString, out var amount) && amount > 0)
            {
                var newExpense = new Record(RecordOwner.Id, RecordType.Expense, amount, description);
                RecordsCollection.InsertOne(newExpense);
                DialogResult = true;
            }
            else
            {
                ErrorBox.Show("Amount must be a positive number.");
            }
        }
    }
}
