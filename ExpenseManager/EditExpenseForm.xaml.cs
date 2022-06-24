using ExpenseManager.DatabaseModels;
using MongoDB.Driver;
using System.Windows;

namespace ExpenseManager
{
    /// <summary>
    /// Interaction logic for EditExpenseForm.xaml
    /// </summary>
    public partial class EditExpenseForm : Window
    {
        private readonly IMongoCollection<Record> RecordsCollection;
        public Record Expense { get; set; }

        public EditExpenseForm(Record expense, IMongoCollection<Record> recordsCollection)
        {
            InitializeComponent();
            Expense = expense;
            RecordsCollection = recordsCollection;
            Loaded += (o, e) => DataContext = Expense;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var amountString = AmountBox.Text;
            var description = DescriptionBox.Text;

            if (double.TryParse(amountString, out var amount) && amount > 0)
            {
                var updateDefinition = Builders<Record>.Update
                    .Set(r => r.Amount, amount)
                    .Set(r => r.Description, description);

                RecordsCollection.FindOneAndUpdate(r => r.Id == Expense.Id, updateDefinition);
                DialogResult = true;
            }
            else
            {
                ErrorBox.Show("Amount must be a positive number.");
            }
        }
    }
}
