using ExpenseManager.DatabaseModels;
using System.Collections.Generic;

namespace ExpenseManager
{
    public static class SigningUpVerifier
    {
        public static bool Verify(string email, string username, string firstPassword, string secondPassword, List<User> existingUsers)
        {
            if (EmptyValuesExist(email, username, firstPassword, secondPassword))
            {
                ErrorBox.Show("All fields must be filled.");
                return false;
            }
            else
            {
                if (existingUsers.Find(u => u.Email.Equals(email)) is not null)
                {
                    ErrorBox.Show("Entered email already exists.");
                    return false;
                }
                else if (existingUsers.Find(u => u.Username.Equals(username)) is not null)
                {
                    ErrorBox.Show("Entered username already exists.");
                    return false;
                }
                else if (!firstPassword.Equals(secondPassword))
                {
                    ErrorBox.Show("Entered passwords do not match.");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private static bool EmptyValuesExist(string email, string username, string firstPassword, string secondPassword)
        {
            return email.Equals(string.Empty)
                || username.Equals(string.Empty)
                || firstPassword.Equals(string.Empty)
                || secondPassword.Equals(string.Empty);
        }
    }
}
