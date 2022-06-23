using System.Windows;

namespace ExpenseManager
{
    /// <summary>
    /// Interaction logic for NewExpenseForm.xaml
    /// </summary>
    public partial class NewExpenseForm : Window
    {
        public NewExpenseForm()
        {
            InitializeComponent();
            AmountBox.Focus();
        }
    }
}
