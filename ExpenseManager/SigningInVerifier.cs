using ExpenseManager.DatabaseModels;
using System.Collections.Generic;

namespace ExpenseManager
{
    public static class SigningInVerifier
    {
        public static bool Verify(string username, string password, List<User> existingUsers)
        {
            return true;
        }
    }
}
