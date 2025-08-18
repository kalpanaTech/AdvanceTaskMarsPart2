using AdvanceTaskMarsPart2.Assertions;
using AdvanceTaskMarsPart2.Hooks;
using AdvanceTaskMarsPart2.Model;
using AdvanceTaskMarsPart2.Steps;
using AdvanceTaskMarsPart2.Utilities;
using NUnit.Framework.Interfaces;
using System;
using TechTalk.SpecFlow;

namespace AdvanceTaskMarsPart2.StepDefinitions
{
    [Binding]
    public class DescriptionFeatureStepDefinitions : Base
    {
        HomePageSteps homePageStepsObj = new HomePageSteps();
        DescriptionSteps descriptionStepsObj = new DescriptionSteps();
        DescriptionAssertions descriptionAssertionsObj = new DescriptionAssertions();

        private List<DescriptionCredentials> addTestData = new List<DescriptionCredentials>();
        private List<DescriptionCredentials> updateTestData = new List<DescriptionCredentials>();
        private List<DescriptionCredentials> deleteTestData = new List<DescriptionCredentials>();
        private List<DescriptionCredentials> invalidTestData = new List<DescriptionCredentials>();

        [Then(@"User navigate to the desctiption on home page")]
        public void ThenUserNavigateToTheDesctiptionOnHomePage()
        {
            homePageStepsObj.ClickOnDescriptionIcon();
        }


        [When(@"User enter desctiption details from the json file located at ""([^""]*)""")]
        public void WhenUserEnterDesctiptionDetailsFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            addTestData = JsonHelper.ReadTestDataFromJson<DescriptionCredentials>(jsonContent);
            foreach (var data in addTestData)
            {
                descriptionStepsObj.AddDescription(data);
            }
        }

        [Then(@"User should be able to successfully add desctiption details")]
        public void ThenUserShouldBeAbleToSuccessfullyAddDesctiptionDetails()
        {
            descriptionAssertionsObj.VerifyDescriptionAssertions(); 
        }

        [When(@"User enter desctiption details to update from the json file located at ""([^""]*)""")]
        public void WhenUserEnterDesctiptionDetailsToUpdateFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            updateTestData = JsonHelper.ReadTestDataFromJson<DescriptionCredentials>(jsonContent);
            foreach (var data in updateTestData)
            {
                descriptionStepsObj.UpdateDescription(data);
            }
        }

        [Then(@"User should be able to successfully update desctiption details")]
        public void ThenUserShouldBeAbleToSuccessfullyUpdateDesctiptionDetails()
        {
            descriptionAssertionsObj.VerifyDescriptionAssertions();
        }

        [When(@"User enter desctiption details to delete from the json file located at ""([^""]*)""")]
        public void WhenUserEnterDesctiptionDetailsToDeleteFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            deleteTestData = JsonHelper.ReadTestDataFromJson<DescriptionCredentials>(jsonContent);
            foreach (var data in deleteTestData)
            {
                descriptionStepsObj.DeleteDescription(data);
            }
        }

        [Then(@"User should be able to successfully delete desctiption details")]
        public void ThenUserShouldBeAbleToSuccessfullyDeleteDesctiptionDetails()
        {
            descriptionAssertionsObj.VerifyDescriptionAssertions();
        }

        [When(@"User enter invalid desctiption details to add from the json file located at ""([^""]*)""")]
        public void WhenUserEnterInvalidDesctiptionDetailsToAddFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            invalidTestData = JsonHelper.ReadTestDataFromJson<DescriptionCredentials>(jsonContent);
            foreach (var data in invalidTestData)
            {
                descriptionStepsObj.AddDescription(data);
            }
        }

        [Then(@"User should be able to test invalid desctiption details")]
        public void ThenUserShouldBeAbleToTestInvalidDesctiptionDetails()
        {
            descriptionAssertionsObj.VerifyDescriptionAssertions();
        }

    }
}
