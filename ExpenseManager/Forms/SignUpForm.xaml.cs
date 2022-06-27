using ExpenseManager.DatabaseModels;
using ExpenseManager.Verifiers;
using MongoDB.Driver;
using System.Windows;

namespace ExpenseManager.Forms
{
    /// <summary>
    /// Interaction logic for SignUpForm.xaml
    /// </summary>
    public partial class SignUpForm : Window
    {
        private readonly IMongoCollection<User> UsersCollection;

        public SignUpForm(IMongoCollection<User> usersCollection)
        {
            InitializeComponent();
            UsersCollection = usersCollection;
            EmailBox.Focus();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailBox.Text;
            var username = UsernameBox.Text;
            var firstPassword = FirstPasswordBox.Password;
            var secondPassword = SecondPasswordBox.Password;
            var existingUsers = UsersCollection.Find(_ => true).ToList();

            if (SigningUpVerifier.Verify(email, username, firstPassword, secondPassword, existingUsers, out var errorText))
            {
                var newUser = new User(email, username, firstPassword);
                UsersCollection.InsertOne(newUser);
                DialogResult = true;
            }
            else
            {
                ErrorBox.Show(errorText);
            }
        }
    }
}
