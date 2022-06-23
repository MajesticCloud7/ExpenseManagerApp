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

        public MainPage(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new NewExpenseForm()
            {
                Owner = MainWindow
            };
            dialog.ShowDialog();
        }
    }
}
