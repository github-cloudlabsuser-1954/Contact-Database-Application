namespace UserSpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class UserStepDefinitions
    {
        //// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        // Step definition for the given step
        [Given(@"I am on the User Index page")]
        public void GivenIAmOnTheUserIndexPage()
        {
            // Add code here to navigate to the User Index page
        }

        // Step definition for the when step
        [When(@"I request a list of all users")]
        public void WhenIRequestAListOfAllUsers()
        {
            // Add code here to request a list of all users
        }

        // Step definition for the then step
        [Then(@"I should see a list of all users")]
        public void ThenIShouldSeeAListOfAllUsers()
        {
            // Add code here to verify that a list of all users is displayed
        }

    }
}
