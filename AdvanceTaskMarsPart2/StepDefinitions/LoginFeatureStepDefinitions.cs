using AdvanceTaskMarsPart2.Assertions;
using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.Process;
using AdvanceTaskMarsPart2.TestModel;
using AdvanceTaskMarsPart2.Utilities;
using AventStack.ExtentReports;
using System;
using TechTalk.SpecFlow;

namespace AdvanceTaskMarsPart2.StepDefinitions
{
    [Binding]
    public class LoginFeatureStepDefinitions : Hooks
    {
        private MainPage hostPageObj = new MainPage();
        private LoginSteps loginObj = new LoginSteps();
        private LoginAssertions loginAssertionsObj = new LoginAssertions();

        private ExtentTest testreport;

        [Given(@"User is on the login page")]
        public void GivenUserIsOnTheLoginPage()
        {
            hostPageObj.ClickSignIn();
        }

        [When(@"User enter valid email and password from the json file located at ""([^""]*)""")]
        public void WhenUserEnterValidEmailAndPasswordFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<LoginCredentials> LoginData = JsonHelper.ReadTestDataFromJson<LoginCredentials>(jsonContent);
            foreach (var data in LoginData)
            {
               
                loginObj.LoginProcess(data);
            }
        }

        [Then(@"User should be logged in successfully")]
        public void ThenUserShouldBeLoggedInSuccessfully()
        {
            loginAssertionsObj.LoginAssertion();
        }
    }
}
