using ExpenseManager.DatabaseModels;
using System.Windows;

namespace ExpenseManager
{
    /// <summary>
    /// Interaction logic for EditExpenseForm.xaml
    /// </summary>
    public partial class EditExpenseForm : Window
    {
        public Record Expense { get; set; }

        public EditExpenseForm(Record expense)
        {
            InitializeComponent();
            Expense = expense;
            Loaded += (o, e) => DataContext = Expense;
        }
    }
}
