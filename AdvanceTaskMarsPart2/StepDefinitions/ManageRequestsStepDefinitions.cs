using AdvanceTaskMarsPart2.Assertions;
using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.Steps;
using AdvanceTaskMarsPart2.Utilities;
using AventStack.ExtentReports;
using System;
using TechTalk.SpecFlow;

namespace AdvanceTaskMarsPart2.StepDefinitions
{
    [Binding]
    public class ManageRequestsStepDefinitions : Hooks
    {
        HomePageSteps homePageStepsObj = new HomePageSteps();
        ManageRequestsTabComponents manageRequestsTabComponentsObj = new ManageRequestsTabComponents();
        ManageReceivedRequestAssertions manageReceivedRequestAssertionsObj = new ManageReceivedRequestAssertions();
        ManageReceivedRequestSteps manageReceivedRequestStepsObj = new ManageReceivedRequestSteps();


        private ExtentTest testreport;

        [Then(@"User navigate to manage requests tab")]
        public void ThenUserNavigateToManageRequestsTab()
        {
            homePageStepsObj.ClickOnManageRequestsTab();
        }

        [Then(@"User navigate to received requests option")]
        public void ThenUserNavigateToReceivedRequestsOption()
        {
            manageRequestsTabComponentsObj.ClickReceivedRequests();
        }

        [When(@"User click on the accept button and view the status")]
        public void WhenUserClickOnTheAcceptButtonAndViewTheStatus()
        {
            manageReceivedRequestStepsObj.AcceptReceivedRequests();
        }

        [Then(@"User can verify accept received request successfully")]
        public void ThenUserCanVerifyAcceptReceivedRequestSuccessfully()
        {
            manageReceivedRequestAssertionsObj.VerifyAcceptManageReceivedRequest();
        }

        [When(@"User click on the decline button and view the status")]
        public void WhenUserClickOnTheDeclineButtonAndViewTheStatus()
        {
            manageReceivedRequestStepsObj.DeclineReceivedRequests();
        }

        [Then(@"User can verify decline received request successfully")]
        public void ThenUserCanVerifyDeclineReceivedRequestSuccessfully()
        {
            manageReceivedRequestAssertionsObj.VerifyDeclineManageReceivedRequest();
        }

        [When(@"User click on the complete button and view the status")]
        public void WhenUserClickOnTheCompleteButtonAndViewTheStatus()
        {
            manageReceivedRequestStepsObj.ViewRequestsAfterCompletingFromUserEnd();
        }

        [Then(@"User can verify completed requests view successfully")]
        public void ThenUserCanVerifyCompletedRequestsViewSuccessfully()
        {
            manageReceivedRequestAssertionsObj.VerifyViewRequestsAfterCompletingFromUserEnd();
        }

        [When(@"User view the completed requests")]
        public void WhenUserViewTheCompletedRequests()
        {
            manageReceivedRequestStepsObj.ViewRequestsAfterCompletingFromSenderEnd();
        }
        [Then(@"User can verify the completed requests view successfully")]
        public void ThenUserCanVerifyTheCompletedRequestsViewSuccessfully()
        {
            manageReceivedRequestAssertionsObj.VerifyViewRequestsAfterCompletingFromSenderEnd();
        }

        [When(@"User view the withdrawn requests")]
        public void WhenUserViewTheWithdrawnRequests()
        {
            manageReceivedRequestStepsObj.ViewRequestsWithdrawnFromSenderEnd();
        }

        [Then(@"User can verify the withdrawn requests view successfully")]
        public void ThenUserCanVerifyTheWithdrawnRequestsViewSuccessfully()
        {
            manageReceivedRequestAssertionsObj.VerifyViewRequestsWithdrawnFromSenderEnd();
        }
    }
}
