using ExpenseManager.DatabaseModels;
using ExpenseManager.Verifiers;

namespace UnitTests
{
    public class SigningUpVerifierTests
    {
        [Theory]
        [MemberData(nameof(VerifyTestCases))]
        public void Verify(string email, string username, string firstPassword, string secondPassword, List<User> existingUsers, bool expected)
        {
            var actual = SigningUpVerifier.Verify(email, username, firstPassword, secondPassword, existingUsers, out _);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> VerifyTestCases =>
            new List<object[]>
            {
                // all empty
                new object[]
                {
                    "", "", "", "",
                    new List<User>(),
                    false
                },

                // one empty
                new object[]
                {
                    "", "user", "password", "password",
                    new List<User>(),
                    false
                },

                // existing email
                new object[]
                {
                    "email", "user", "password", "password",
                    new List<User>
                    {
                        new User("email", "username", "password")
                    },
                    false
                },

                // existing username
                new object[]
                {
                    "email", "user", "password", "password",
                    new List<User>
                    {
                        new User("emailAddress", "user", "password")
                    },
                    false
                },
                
                // unmatching passwords
                new object[]
                {
                    "email", "user", "password1", "password2",
                    new List<User>(),
                    false
                },
                
                // valid new user
                new object[]
                {
                    "email", "user", "password", "password",
                    new List<User>(),
                    true
                },
            };
    }
}
