using ExpenseManager.DatabaseModels;
using ExpenseManager.Verifiers;
using MongoDB.Driver;
using System.Windows;

namespace ExpenseManager.Forms
{
    /// <summary>
    /// Interaction logic for SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {
        private readonly IMongoCollection<User> UsersCollection;
        public User SignedInUser { get; private set; }

        public SignInForm(IMongoCollection<User> usersCollection)
        {
            InitializeComponent();
            UsersCollection = usersCollection;
            UsernameBox.Focus();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameBox.Text;
            var password = PasswordBox.Password;
            var existingUsers = UsersCollection.Find(_ => true).ToList();

            if (SigningInVerifier.Verify(username, password, existingUsers, out var errorText))
            {
                SignedInUser = UsersCollection.Find(u => u.Username.Equals(username)).First();
                DialogResult = true;
            }
            else
            {
                ErrorBox.Show(errorText);
            }
        }
    }
}
