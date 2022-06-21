using System.Windows;

namespace ExpenseManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SignUpForm();
            dialog.Owner = this;
            dialog.ShowDialog();
        }
    }
}
