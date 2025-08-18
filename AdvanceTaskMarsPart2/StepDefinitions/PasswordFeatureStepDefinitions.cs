using AdvanceTaskMarsPart2.Assertions;
using AdvanceTaskMarsPart2.Hooks;
using AdvanceTaskMarsPart2.Model;
using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.Steps;
using AdvanceTaskMarsPart2.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using System;
using TechTalk.SpecFlow;

namespace AdvanceTaskMarsPart2.StepDefinitions
{
    [Binding]
    public class PasswordFeatureStepDefinitions : Base
    {
        HomePageSteps homePageStepsObj = new HomePageSteps();
        UserTabComponents userTabComponentsObj = new UserTabComponents();
        PasswordChangeSteps passwordChangeStepsObj = new PasswordChangeSteps();
        PasswordAssertions passwordAssertionsObj = new PasswordAssertions();

        private List<ChangePasswordCredentials> passwordTestData = new List<ChangePasswordCredentials>();



        [Then(@"User navigate to change password option")]
        public void ThenUserNavigateToChangePasswordOption()
        {
            homePageStepsObj.ClickOnUserCheckingOption();
            userTabComponentsObj.ClickChangePassword();
        }

        [When(@"User enter passwords from the json file located at ""([^""]*)""")]
        public void WhenUserEnterPasswordsFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            passwordTestData = JsonHelper.ReadTestDataFromJson<ChangePasswordCredentials>(jsonContent);
            foreach (var data in passwordTestData)
            {
                passwordChangeStepsObj.ChangePassword(data);
            }          
        }

        [Then(@"User should be able to successfully change the password")]
        public void ThenUserShouldBeAbleToSuccessfullyChangeThePassword()
        {
            passwordAssertionsObj.VerifyPasswordChangeAssertions();
        }

        [When(@"User enter invalid passwords from the json file located at ""([^""]*)""")]
        public void WhenUserEnterInvalidPasswordsFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            passwordTestData = JsonHelper.ReadTestDataFromJson<ChangePasswordCredentials>(jsonContent);
            foreach (var data in passwordTestData)
            {
                passwordChangeStepsObj.ChangePasswordWithInvalidData(data);
            }
        }

        [Then(@"User should be able to test invalid passwords")]
        public void ThenUserShouldBeAbleToTestInvalidPasswords()
        {
            passwordAssertionsObj.VerifyPasswordChangeAssertions();
        }

    }
}
