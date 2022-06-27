using ExpenseManager.DatabaseModels;
using ExpenseManager.Verifiers;

namespace UnitTests
{
    public class SigningInVerifierTests
    {
        [Theory]
        [MemberData(nameof(VerifyTestCases))]
        public void Verify(string username, string password, List<User> existingUsers, bool expected)
        {
            var actual = SigningInVerifier.Verify(username, password, existingUsers, out _);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> VerifyTestCases =>
            new List<object[]>
            {
                // both empty
                new object[]
                {
                    "", "",
                    new List<User>(),
                    false
                },

                // one empty
                new object[]
                {
                    "user", "",
                    new List<User>(),
                    false
                },

                // username does not exist
                new object[]
                {
                    "user", "password",
                    new List<User>
                    {
                        new User("email", "username", "password")
                    },
                    false
                },

                // wrong password
                new object[]
                {
                    "user", "pass",
                    new List<User>
                    {
                        new User("email", "user", "password")
                    },
                    false
                },
                
                // valid user
                new object[]
                {
                    "user", "password",
                    new List<User>
                    {
                        new User("email", "user", "password")
                    },
                    true
                },
            };
    }
}
