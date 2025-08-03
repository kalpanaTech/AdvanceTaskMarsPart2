using AdvanceTaskMarsPart2.Assertions;
using AdvanceTaskMarsPart2.Model;
using AdvanceTaskMarsPart2.Steps;
using AdvanceTaskMarsPart2.Utilities;
using NUnit.Framework.Interfaces;
using System;
using TechTalk.SpecFlow;

namespace AdvanceTaskMarsPart2.StepDefinitions
{
    [Binding]
    public class ManageListingFeatureStepDefinitions : Hooks
    {
        HomePageSteps homePageStepsObj = new HomePageSteps();
        ManageListingsSteps manageListingsStepsObj = new ManageListingsSteps();
        ManageListingsAssertions manageListingsAssertionsObj = new ManageListingsAssertions();
        private bool toggleClicked;

        private List<ManageListingsCredentials> editTestData = new List<ManageListingsCredentials>();
        private List<ManageListingsCredentials> sendRequestTestData = new List<ManageListingsCredentials>();

        [Then(@"User navigate to manage listings tab")]
        public void ThenUserNavigateToManageListingsTab()
        {
            homePageStepsObj.ClickOnManageListingsTab();
        }

        [When(@"User view manage listings")]
        public void WhenUserViewManageListings()
        {
            manageListingsStepsObj.ViewManageListings();
        }

        [Then(@"User can verify view manage listings successfully")]
        public void ThenUserCanVerifyViewManageListingsSuccessfully()
        {
            manageListingsAssertionsObj.VerifyViewManageListings();
        }


        [When(@"User edit manage listings from the json file located at ""([^""]*)""")]
        public void WhenUserEditManageListingsFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            editTestData = JsonHelper.ReadTestDataFromJson<ManageListingsCredentials>(jsonContent);
            foreach (var data in editTestData)
            {
                manageListingsStepsObj.EditManageListings(data);
            }
        }

        [Then(@"User can view the updated manage listings successfully")]
        public void ThenUserCanViewTheUpdatedManageListingsSuccessfully()
        {
            foreach (var data in editTestData)
            {
                manageListingsAssertionsObj.VerifyEditManageListings(data);
            }               
        }
        [When(@"User delete manage listings")]
        public void WhenUserDeleteManageListings()
        {
            manageListingsStepsObj.DeleteManageListings();
        }

        [Then(@"User can verify delete manage listings successfully")]
        public void ThenUserCanVerifyDeleteManageListingsSuccessfully()
        {
            manageListingsAssertionsObj.VerifyManageListingsDelete();
        }

        [When(@"User search profile and enter request message from the json file located at ""([^""]*)""")]
        public void WhenUserSearchProfileAndEnterRequestMessageFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            sendRequestTestData = JsonHelper.ReadTestDataFromJson<ManageListingsCredentials>(jsonContent);
            foreach (var data in sendRequestTestData)
            {
                manageListingsStepsObj.SendManageListingsRequest(data);
            }
        }

        [Then(@"User can verify send manage listings requests successfully")]
        public void ThenUserCanVerifySendManageListingsRequestsSuccessfully()
        {
            manageListingsAssertionsObj.VerifyManageListingsSendRequest();
        }

        [When(@"User activate manage listings")]
        public void WhenUserActivateManageListings()
        {
            toggleClicked = manageListingsStepsObj.AcivateManageListings();
        }

        [Then(@"User can verify (activate|deactivate) manage listings successfully")]
        public void ThenUserCanVerifyActivateManageListingsSuccessfully(string option1)
        {
            if (toggleClicked)
            {
                manageListingsAssertionsObj.VerifyManageListingsToggleActions();
            }
            else
            {
                Console.WriteLine("No click happened, skipping toast verification. Service currently on the required state");
            }
        }

        [When(@"User deactivate manage listings")]
        public void WhenUserDeactivateManageListings()
        {
            toggleClicked = manageListingsStepsObj.DeacivateManageListings();
        }
    }
}
