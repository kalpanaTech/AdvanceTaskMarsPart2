using AdvanceTaskMarsPart2.Assertions;
using AdvanceTaskMarsPart2.Hooks;
using AdvanceTaskMarsPart2.Model;
using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.Steps;
using AdvanceTaskMarsPart2.Utilities;
using AventStack.ExtentReports;
using System;
using TechTalk.SpecFlow;

namespace AdvanceTaskMarsPart2.StepDefinitions
{
    [Binding]
    public class ManageSentRequestsStepDefinitions : Base
    {
        
        ManageRequestsTabComponents manageRequestsTabComponentsObj = new ManageRequestsTabComponents();
        ManageSentRequestSteps manageSentRequestStepsObj = new ManageSentRequestSteps();
        ManageSentRequestAssertions manageSentRequestAssertionsObj = new ManageSentRequestAssertions();

        private List<SentRequestCredentials> reviewTestData = new List<SentRequestCredentials>();


        

        [Then(@"User navigate to sent requests option")]
        public void ThenUserNavigateToSentRequestsOption()
        {
            manageRequestsTabComponentsObj.ClickSentRequests();
        }

        [When(@"User click on the withdraw button")]
        public void WhenUserClickOnTheWithdrawButton()
        {
            manageSentRequestStepsObj.WithdrawSentRequests();
        }

        [Then(@"User can verify the withdraw request successfully")]
        public void ThenUserCanVerifyTheWithdrawRequestSuccessfully()
        {
            manageSentRequestAssertionsObj.VerifyWithdrawSentRequests();
        }

        [When(@"User click on the completed button")]
        public void WhenUserClickOnTheCompletedButton()
        {
            manageSentRequestStepsObj.UpdateCompletedSentRequests();
        }

        [Then(@"User can verify the completed request successfully")]
        public void ThenUserCanVerifyTheCompletedRequestSuccessfully()
        {
            manageSentRequestAssertionsObj.VerifyUpdateCompletedSentRequest();
        }

        [When(@"User review the service from the json file located at ""([^""]*)""")]
        public void WhenUserReviewTheServiceFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            reviewTestData = JsonHelper.ReadTestDataFromJson<SentRequestCredentials>(jsonContent);
            foreach (var data in reviewTestData)
            {
                manageSentRequestStepsObj.ReviewSentRequests(data);
            }
        }

        [Then(@"User can verify the review service successfully")]
        public void ThenUserCanVerifyTheReviewServiceSuccessfully()
        {
            manageSentRequestAssertionsObj.VerifyReviewSentRequests();
        }

        [When(@"User view the declined requests")]
        public void WhenUserViewTheDeclinedRequests()
        {
            manageSentRequestStepsObj.ViewDeclinedSentRequests();
        }

        [Then(@"User can verify view declined requests successfully")]
        public void ThenUserCanVerifyViewDeclinedRequestsSuccessfully()
        {
            manageSentRequestAssertionsObj.VerifyViewDeclinedSentRequests();
        }
    }
}
