using ExpenseManager.DatabaseModels;
using SpecFlow.Actions.WindowsAppDriver;

namespace BDDTests.Drivers.E2E
{
    public class NewExpenseForm : NewExpenseFormElements
    {
        public NewExpenseForm(AppDriver appDriver) : base(appDriver)
        {
        }

        public void EnterAmount(string amount)
        {
            AmountTextBox.SendKeys(amount);
        }

        public void EnterDescription(string description)
        {
            DescriptionTextBox.SendKeys(description);
        }

        public void ClickAdd()
        {
            AddButton.Click();
        }
    }
}
