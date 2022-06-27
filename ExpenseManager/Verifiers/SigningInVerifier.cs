using ExpenseManager.DatabaseModels;
using System.Collections.Generic;

namespace ExpenseManager.Verifiers
{
    public static class SigningInVerifier
    {
        public static bool Verify(string username, string password, List<User> existingUsers, out string errorText)
        {
            if (EmptyValuesExist(username, password))
            {
                errorText = "Both fields must be filled.";
                return false;
            }
            else
            {
                var user = existingUsers.Find(u => u.Username.Equals(username));
                if (user is null)
                {
                    errorText = "Entered username does not exist.";
                    return false;
                }
                else
                {
                    if (!user.Password.Equals(password))
                    {
                        errorText = "Wrong password.";
                        return false;
                    }
                    else
                    {
                        errorText = string.Empty;
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
