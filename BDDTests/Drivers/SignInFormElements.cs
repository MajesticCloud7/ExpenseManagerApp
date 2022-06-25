using OpenQA.Selenium.Appium.Windows;
using SpecFlow.Actions.WindowsAppDriver;

namespace BDDTests.Drivers
{
    public class SignInFormElements
    {
        private readonly AppDriver AppDriver;

        public SignInFormElements(AppDriver appDriver)
        {
            AppDriver = appDriver;
        }

        public void LoadSignInForm()
        {
            AppDriver.Current.FindElementByAccessibilityId("SignInButton").Click();
        }

        public WindowsElement UsernameTextBox =>
            AppDriver.Current.FindElementByAccessibilityId("UsernameBox");

        public WindowsElement PasswordBox =>
            AppDriver.Current.FindElementByAccessibilityId("PasswordBox");

        public WindowsElement SignInButton =>
            AppDriver.Current.FindElementByAccessibilityId("SignInButton");

        public bool IsUserSignedIn()
        {
            try
            {
                var signOutButton = AppDriver.Current.FindElementByAccessibilityId("SignOutButton");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
