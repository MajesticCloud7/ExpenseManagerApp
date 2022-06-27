using ExpenseManager.DatabaseModels;
using OpenQA.Selenium.Appium.Windows;
using SpecFlow.Actions.WindowsAppDriver;

namespace BDDTests.Drivers.E2E
{
    public class NewExpenseFormElements
    {
        private readonly AppDriver AppDriver;
        private readonly SignInForm SignInForm;

        public NewExpenseFormElements(AppDriver appDriver)
        {
            AppDriver = appDriver;
            SignInForm = new SignInForm(AppDriver);
        }

        public void LoadSignInForm()
        {
            SignInForm.LoadSignInForm();
        }

        public void LoadMainPage(User existingUser)
        {
            SignInForm.EnterUsername(existingUser.Username);
            SignInForm.EnterPassword(existingUser.Password);
            SignInForm.ClickSignIn();
        }

        public void LoadNewExpenseForm()
        {
            AppDriver.Current.FindElementByAccessibilityId("AddExpenseButton").Click();
        }

        public WindowsElement AmountTextBox =>
            AppDriver.Current.FindElementByAccessibilityId("AmountBox");

        public WindowsElement DescriptionTextBox =>
            AppDriver.Current.FindElementByAccessibilityId("DescriptionBox");

        public WindowsElement AddButton =>
            AppDriver.Current.FindElementByAccessibilityId("AddButton");

        public bool ErrorOccured()
        {
            try
            {
                var errorBox = AppDriver.Current.FindElementByName("Error");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
