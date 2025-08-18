using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using AdvanceTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart2.Hooks
{
    [Binding]
    public class ExtentHooks : Base
    {
        public static ExtentReports extent;
        public static ExtentTest feature;
        public static ExtentTest testScenario;
        public static ExtentSparkReporter htmlReporter;
        public static ExtentTest test;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentSparkReporter("C:\\repo\\AdvanceTaskMarsPart2\\AdvanceTaskMarsPart2\\AdvanceTaskMarsPart2\\Reports\\ExtentReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            htmlReporter.Config.ReportName = "Mars Advance Task Part 2 Test Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;

            extent.AddSystemInfo("Tester", "Kalpana Dissanayake");

          
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            string featureTitle = featureContext.FeatureInfo.Title;
            feature = extent.CreateTest(featureTitle);

        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            testScenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            ReportManager.SetTest(testScenario);

        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            var test = ReportManager.GetTest();

            if (scenarioContext.TestError != null)
            {
                test.Fail("Scenario failed: " + scenarioContext.TestError.Message);
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
                test.Pass("Scenario passed");
            }
        }


        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }
    }
}
