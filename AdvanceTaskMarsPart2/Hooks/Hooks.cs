using AdvanceTaskMarsPart2.Steps;
using AdvanceTaskMarsPart2.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace AdvanceTaskMarsPart2.Hooks
{
    [Binding]
    public class Hooks : Base
    {
        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            SetupAuction();

        }

        

        [AfterScenario]
        public void AfterScenario()
        {
           /* var outcome = TestContext.CurrentContext.Result.Outcome.Status;

            if (outcome == TestStatus.Failed)
            {
                try
                {
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                    string screenshotDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
                    if (!Directory.Exists(screenshotDirectory))
                        Directory.CreateDirectory(screenshotDirectory);

                    string safeTestName = string.Join("_", TestContext.CurrentContext.Test.Name.Split(Path.GetInvalidFileNameChars()));
                    string screenshotFile = $"{safeTestName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                    string screenshotPath = Path.Combine(screenshotDirectory, screenshotFile);

                    screenshot.SaveAsFile(screenshotPath);
                    test.Fail("Test failed").AddScreenCaptureFromPath(screenshotPath);
                }
                catch (Exception ex)
                {
                    test.Fail("Failed to capture screenshot: " + ex.Message);
                }
            }
            else
            {
                test.Pass("Test passed");
            } */

            TearDownAction();
        }

    }

}
