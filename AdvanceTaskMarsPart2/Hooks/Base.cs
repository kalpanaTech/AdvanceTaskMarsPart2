using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Hooks
{
    public class Base
    {
        public static IWebDriver driver;
        //private static ExtentReports extent;
        //private static ExtentTest testreport;

        [SetUp]
        public void SetupAuction()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5003/");
            driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void TearDownAction()
        {
            driver.Quit();
        }
    }
}
