using AdvanceTaskMarsPart2.Assertions;
using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.Steps;
using AdvanceTaskMarsPart2.TestModel;
using AdvanceTaskMarsPart2.Utilities;
using AventStack.ExtentReports;
using CompetionTaskMars.Model;
using System;
using TechTalk.SpecFlow;

namespace AdvanceTaskMarsPart2.StepDefinitions
{
    [Binding]
    public class EducationFeatureStepDefinitions : Hooks
    {
        ProfileMenuTabsComponents profileMenuTabsComponentsObj = new ProfileMenuTabsComponents();
        HomePageSteps homePageStepsObj = new HomePageSteps();
        ProfileEducationOverviewComponent profileEducationOverviewComponentObj = new ProfileEducationOverviewComponent();
        EducationSteps educationStepsObj = new EducationSteps();
        EducationAssertions educationAssertionsObj = new EducationAssertions();

        private ExtentTest testreport;

        [Then(@"User navigate to education tab")]
        public void ThenUserNavigateToEducationTab()
        {
            homePageStepsObj.ClickOnProfileTab();
            profileMenuTabsComponentsObj.ClickEducationTab();
        }


        [When(@"User enter education details from the json file located at ""([^""]*)""")]
        public void WhenUserEnterEducationDetailsFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<EducationCredentials> EducationAddTestData = JsonHelper.ReadTestDataFromJson<EducationCredentials>(jsonContent);
            foreach (var data in EducationAddTestData)
            {
                educationStepsObj.AddEducation(data);
            }
        }

        [Then(@"User should be able to successfully add education details")]
        public void ThenUserShouldBeAbleToSuccessfullyAddEducationDetails()
        {
            educationAssertionsObj.AddEducationAssertions();
        }

        [Then(@"Remove existing education data")]
        public void ThenRemoveExistingEducationData()
        {
            homePageStepsObj.ClickOnProfileTab();
            profileMenuTabsComponentsObj.ClickEducationTab();
            profileMenuTabsComponentsObj.RemoveAddedEducationDetails();
            
        }

        [When(@"User enter education details to delete from the json file located at ""([^""]*)""")]
        public void WhenUserEnterEducationDetailsToDeleteFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<EducationCredentials> EducationDeleteTestData = JsonHelper.ReadTestDataFromJson<EducationCredentials>(jsonContent);
            foreach (var data in EducationDeleteTestData)
            {
                educationStepsObj.DeleteEducation(data);


            }
        }

        [Then(@"User should be able to successfully delete education details")]
        public void ThenUserShouldBeAbleToSuccessfullyDeleteEducationDetails()
        {
            educationAssertionsObj.DeleteEducationAssertions();
        }



    }
}
