using BDDTests.Drivers;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public sealed class SignInFullStepDefinitions : StepDefinitionsBase
    {
        private readonly SignInForm SignInForm;

        public SignInFullStepDefinitions(SignInForm signInForm) : base()
        {
            SignInForm = signInForm;
        }

        [When(@"user enters username")]
        public async void WhenUserEntersUsername()
        {
            await Task.Delay(MillisecondsDelay);
            SignInForm.EnterUsername("test");
        }

        [When(@"user enters password")]
        public async void WhenUserEntersPassword()
        {
            await Task.Delay(MillisecondsDelay);
            SignInForm.EnterPassword("test");
        }

        [When(@"user enters not existing username")]
        public async void WhenUserEntersNotExistingUsername()
        {
            await Task.Delay(MillisecondsDelay);
            SignInForm.EnterUsername("*******");
        }
    }
}
