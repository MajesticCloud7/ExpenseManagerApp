using ExpenseManager.DatabaseModels;
using System.Collections.Generic;

namespace ExpenseManager.Verifiers
{
    public static class SigningInVerifier
    {
        public static bool Verify(string username, string password, List<User> existingUsers)
        {
            if (EmptyValuesExist(username, password))
            {
                ErrorBox.Show("Both fields must be filled.");
                return false;
            }
            else
            {
                var user = existingUsers.Find(u => u.Username.Equals(username));
                if (user is null)
                {
                    ErrorBox.Show("Entered username does not exist.");
                    return false;
                }
                else
                {
                    if (!user.Password.Equals(password))
                    {
                        ErrorBox.Show("Wrong password.");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private static bool EmptyValuesExist(string username, string password)
        {
            return username.Equals(string.Empty)
                || password.Equals(string.Empty);
        }
    }
}
