using BDDTests.Drivers.E2E;
using MongoDB.Driver;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public sealed class NewExpenseStepDefinitions : StepDefinitionsBase
    {
        private readonly NewExpenseForm NewExpenseForm;

        public NewExpenseStepDefinitions(NewExpenseForm newExpenseForm) : base()
        {
            NewExpenseForm = newExpenseForm;
        }

        [Given(@"the new expense form is loaded")]
        public void GivenTheMainPageIsLoaded()
        {
            NewExpenseForm.LoadSignInForm();
            NewExpenseForm.LoadMainPage(Users.First());
            NewExpenseForm.LoadNewExpenseForm();
        }

        [When(@"user enters ""([^""]*)"" in amount field")]
        public void WhenUserEntersInAmountField(string amount)
        {
            NewExpenseForm.EnterAmount(amount);
        }

        [When(@"user enters ""([^""]*)"" in description field")]
        public void WhenUserEntersInDescriptionField(string description)
        {
            NewExpenseForm.EnterDescription(description);
        }

        [When(@"user clicks Add button")]
        public void WhenUserClicksAddButton()
        {
            NewExpenseForm.ClickAdd();
        }

        [Then(@"new expense should not be added")]
        public async void ThenNewExpenseShouldNotBeAdded()
        {
            await Task.Delay(MillisecondsDelay);
            var errorOcurred = NewExpenseForm.ErrorOccured();
            errorOcurred.Should().BeTrue();
        }

        [Then(@"new expense should be added")]
        public async void ThenNewExpenseShouldBeAdded()
        {
            await Task.Delay(MillisecondsDelay);
            var errorOcurred = NewExpenseForm.ErrorOccured();
            errorOcurred.Should().BeFalse();
        }
    }
}
