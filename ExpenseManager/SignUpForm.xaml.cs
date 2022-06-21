using ExpenseManager.DatabaseModels;
using MongoDB.Driver;
using System.Windows;

namespace ExpenseManager
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
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailBox.Text;
            var username = UsernameBox.Text;
            var firstPassword = FirstPasswordBox.Password;
            var secondPassword = SecondPasswordBox.Password;

            if (email.Equals(string.Empty) ||
                username.Equals(string.Empty) ||
                firstPassword.Equals(string.Empty) ||
                secondPassword.Equals(string.Empty))
            {
                MessageBox.Show("All fields must be filled.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var existingUsers = UsersCollection.Find(_ => true).ToList();
                if (existingUsers.Find(u => u.Email.Equals(email)) is not null)
                {
                    MessageBox.Show("Entered email already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (existingUsers.Find(u => u.Username.Equals(username)) is not null)
                {
                    MessageBox.Show("Entered username already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (!firstPassword.Equals(secondPassword))
                {
                    MessageBox.Show("Entered passwords do not match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var newUser = new User(email, username, firstPassword);
                    UsersCollection.InsertOne(newUser);
                }
            }
        }
    }
}
