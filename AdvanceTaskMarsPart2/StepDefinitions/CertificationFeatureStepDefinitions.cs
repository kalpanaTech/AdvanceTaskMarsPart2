using AdvanceTaskMarsPart2.Assertions;
using AdvanceTaskMarsPart2.Model;
using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.Steps;
using AdvanceTaskMarsPart2.Utilities;
using AventStack.ExtentReports;
using CompetionTaskMars.Model;
using NUnit.Framework.Interfaces;
using System;
using TechTalk.SpecFlow;

namespace AdvanceTaskMarsPart2.StepDefinitions
{
    [Binding]
    public class CertificationFeatureStepDefinitions : Hooks
    {
        ProfileMenuTabsComponents profileMenuTabsComponentsObj = new ProfileMenuTabsComponents();
        HomePageSteps homePageStepsObj = new HomePageSteps();
        ProfileCertificationOverviewComponent profileCertificationOverviewComponentObj = new ProfileCertificationOverviewComponent();
        CertificationSteps certificationStepsObj = new CertificationSteps();
        CertificationAssertions certificationAssertionsObj = new CertificationAssertions();

        private List<CertificationCredentials> testData = new List<CertificationCredentials>();
        private List<CertificationCredentials> deleteTestData = new List<CertificationCredentials>();

        private ExtentTest testreport;

        [Given(@"User navigate to certification tab")]
        public void GivenUserNavigateToCertificationTab()
        {
            homePageStepsObj.ClickOnProfileTab();
            profileMenuTabsComponentsObj.ClickCertificationTab();
        }

        [When(@"User enter certification details from the json file located at ""([^""]*)""")]
        public void WhenUserEnterCertificationDetailsFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            testData = JsonHelper.ReadTestDataFromJson<CertificationCredentials>(jsonContent);
            foreach (var data in testData)
            {
                certificationStepsObj.AddCertification(data);


            }
        }

        [Then(@"User should be able to successfully add certification details")]
        public void ThenUserShouldBeAbleToSuccessfullyAddCertificationDetails()
        {
            foreach (var data in testData)
            {
                certificationAssertionsObj.AddCertificationAssertions(data);
            }
        }

        [Then(@"Remove existing certification data")]
        public void ThenRemoveExistingCertificationData()
        {
            homePageStepsObj.ClickOnProfileTab();
            profileMenuTabsComponentsObj.ClickCertificationTab();
            profileMenuTabsComponentsObj.RemoveAddedCertificationDetails();
        }


        [When(@"User enter certification details to delete from the json file located at ""([^""]*)""")]
        public void WhenUserEnterCertificationDetailsToDeleteFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            deleteTestData = JsonHelper.ReadTestDataFromJson<CertificationCredentials>(jsonContent);
            foreach (var data in deleteTestData)
            {
                certificationStepsObj.DeleteEducation(data);
            }
        }

        [Then(@"User should be able to successfully delete certification details")]
        public void ThenUserShouldBeAbleToSuccessfullyDeleteCertificationDetails()
        {
            foreach (var data in deleteTestData)
            {
                certificationAssertionsObj.DeleteCertificationAssertions(data);
            }
        }
    }
}
