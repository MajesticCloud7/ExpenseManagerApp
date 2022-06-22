using ExpenseManager.DatabaseModels;
using MongoDB.Driver;
using System.Windows;

namespace ExpenseManager
{
    /// <summary>
    /// Interaction logic for SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {
        private readonly IMongoCollection<User> UsersCollection;

        public SignInForm(IMongoCollection<User> usersCollection)
        {
            InitializeComponent();
            UsersCollection = usersCollection;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameBox.Text;
            var password = PasswordBox.Password;
            var existingUsers = UsersCollection.Find(_ => true).ToList();

            if (SigningInVerifier.Verify(username, password, existingUsers))
            {
                // TODO: open main app window
            }
        }
    }
}
