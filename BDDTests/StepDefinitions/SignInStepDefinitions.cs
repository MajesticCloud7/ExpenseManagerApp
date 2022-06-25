using BDDTests.Drivers;
using ExpenseManager.DatabaseModels;
using MongoDB.Driver;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public sealed class SignInStepDefinitions
    {
        private const string ConnectionString = "mongodb://127.0.0.1:27017";
        private const string DatabaseName = "ExpenseManagerDB";
        private const string UsersCollectionName = "Users";
        private readonly List<User> Users;
        private readonly SignInForm SignInForm;

        public SignInStepDefinitions(SignInForm signInForm)
        {
            SignInForm = signInForm;
            var mongoClient = new MongoClient(ConnectionString);
            var database = mongoClient.GetDatabase(DatabaseName);
            var usersCollection = database.GetCollection<User>(UsersCollectionName);
            Users = usersCollection.Find(_ => true).ToList();
        }

        [Given(@"the sign in form is loaded")]
        public void GivenTheSignInFormIsLoaded()
        {
            SignInForm.LoadSignInForm();
        }

        [When(@"user enters valid username and password")]
        public void WhenUserEntersValidUsernameAndPassword()
        {
            var user = Users.First();
            SignInForm.EnterUsername(user.Username);
            SignInForm.EnterPassword(user.Password);
        }

        [When(@"user clicks Sign In button")]
        public void WhenUserClicksSignInButton()
        {
            SignInForm.ClickSignIn();
        }

        [Then(@"user should be signed in")]
        public void ThenUserShouldBeSignedIn()
        {
            var result = SignInForm.IsUserSignedIn();
            result.Should().BeTrue();
        }

        [When(@"user enters wrong password")]
        public void WhenUserEntersWrongPassword()
        {
            var user = Users.First();
            SignInForm.EnterUsername(user.Username);
            SignInForm.EnterPassword($"{user.Password}*");
        }

        [Then(@"user should not be signed in")]
        public void ThenUserShouldNotBeSignedIn()
        {
            var result = SignInForm.IsUserSignedIn();
            result.Should().BeFalse();
        }
    }
}
