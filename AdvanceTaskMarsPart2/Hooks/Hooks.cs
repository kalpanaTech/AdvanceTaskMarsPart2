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

            TearDownAction();
        }

    }

}
