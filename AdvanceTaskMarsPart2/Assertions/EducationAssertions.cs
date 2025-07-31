using AdvanceTaskMarsPart2.Utilities;
using AventStack.ExtentReports;
using CompetionTaskMars.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Assertions
{
    public class EducationAssertions : Hooks
    {
        
        private static readonly By cancelButtonLocator = By.XPath("//input[@value='Cancel']");
        private static IWebElement cancelButton;

        
        private static string AddEduMessage = "Education has been added";
        private static string UpdateEduMessage = "Education has been updated"; // fixed typo
        private static string DeleteEduMessage = "Education entry successfully removed";
        private static string AddExistingEduMessage = "This information is already exist.";
        private static string AddInvalidEduMessage = "Please enter all the fields";

        
        public void AddEducationAssertions()
        {
            var test = ReportManager.GetTest();

            
            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver,
                AddEduMessage,
                AddInvalidEduMessage,
                AddExistingEduMessage);

            if (displayedMessage == AddInvalidEduMessage || displayedMessage == AddExistingEduMessage)
            {
                test.Pass("Entered invalid education data: " + displayedMessage);
                cancelButton = driver.FindElement(cancelButtonLocator);
                cancelButton.Click();
            }
            else if (displayedMessage == AddEduMessage)
            {
                test.Pass("Education added successfully: " + displayedMessage);
            }
            else
            {
                test.Fail("Unexpected add education message: " + displayedMessage);
            }
        }

        
        public void UpdateEducationAssertions()
        {
            var test = ReportManager.GetTest();

            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver,
                UpdateEduMessage,
                AddInvalidEduMessage);

            if (displayedMessage == UpdateEduMessage)
            {
                test.Pass("Education updated successfully: " + displayedMessage);
            }
            else if (displayedMessage == AddInvalidEduMessage)
            {
                test.Pass("Invalid update data: " + displayedMessage);
                cancelButton = driver.FindElement(cancelButtonLocator);
                cancelButton.Click();
            }
            else
            {
                test.Fail("Unexpected update education message: " + displayedMessage);
            }
        }

        
        public void DeleteEducationAssertions()
        {
            var test = ReportManager.GetTest();

            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver,
                DeleteEduMessage);

            if (displayedMessage == DeleteEduMessage)
            {
                test.Pass("Education deleted successfully: " + displayedMessage);
            }
            else
            {
                test.Fail("Unexpected delete education message: " + displayedMessage);
            }
        }


    }
}
