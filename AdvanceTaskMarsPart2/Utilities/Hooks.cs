using AdvanceTaskMarsPart2.Steps;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace AdvanceTaskMarsPart2.Utilities
{
    [Binding]
    public class Hooks : Driver
    {
        public static IWebDriver driver;

        public static ExtentReports extent;
        public static ExtentTest feature;
        //public static ExtentTest scenario;
        //public static ExtentSparkReporter htmlReporter;
        public static ExtentTest test;
        

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "ExtentReport.html");
            var htmlReporter = new ExtentSparkReporter(reportPath);

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void FlushReport()
        {
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = extent.CreateTest(featureContext.FeatureInfo.Title);

            driver = InitializeDriver("chrome");
            driver.Navigate().GoToUrl("http://localhost:5003/");
           
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            driver.Quit();
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            test = feature.CreateNode(scenarioContext.ScenarioInfo.Title);
            ReportManager.SetTest(test);
          
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;

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
            }
        }
    }

}
