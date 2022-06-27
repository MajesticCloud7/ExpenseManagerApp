using BDDTests.Drivers;
using MongoDB.Driver;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public sealed class SignInStepDefinitions : StepDefinitionsBase
    {
        private readonly SignInForm SignInForm;

        public SignInStepDefinitions(SignInForm signInForm) : base()
        {
            SignInForm = signInForm;
        }

        [Given(@"the sign in form is loaded")]
        public void GivenTheSignInFormIsLoaded()
        {
            SignInForm.LoadSignInForm();
        }

        [When(@"user enters valid username and password")]
        public async void WhenUserEntersValidUsernameAndPassword()
        {
            await Task.Delay(MillisecondsDelay);
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
        public async void ThenUserShouldBeSignedIn()
        {
            await Task.Delay(MillisecondsDelay);
            var result = SignInForm.IsUserSignedIn();
            result.Should().BeTrue();
        }

        [When(@"user enters wrong password")]
        public async void WhenUserEntersWrongPassword()
        {
            await Task.Delay(MillisecondsDelay);
            var user = Users.First();
            SignInForm.EnterUsername(user.Username);
            SignInForm.EnterPassword($"{user.Password}*");
        }

        [Then(@"user should not be signed in")]
        public async void ThenUserShouldNotBeSignedIn()
        {
            await Task.Delay(MillisecondsDelay);
            var result = SignInForm.IsUserSignedIn();
            result.Should().BeFalse();
        }
    }
}
