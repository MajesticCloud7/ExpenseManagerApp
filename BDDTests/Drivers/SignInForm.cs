using SpecFlow.Actions.WindowsAppDriver;

namespace BDDTests.Drivers
{
    public class SignInForm : SignInFormElements
    {
        public SignInForm(AppDriver appDriver) : base(appDriver)
        {
        }

        public void EnterUsername(string username)
        {
            UsernameTextBox.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordBox.SendKeys(password);
        }

        public void ClickSignIn()
        {
            SignInButton.Click();
        }
    }
}
