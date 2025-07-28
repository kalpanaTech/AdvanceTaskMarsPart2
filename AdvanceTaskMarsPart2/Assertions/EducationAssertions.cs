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
        private static readonly By toastMessageLocator = By.XPath("//div[@class = 'ns-box-inner']");
        private static IWebElement toastMessage;

        private static readonly By cancelButtonLocator = By.XPath("//input[@value='Cancel']");
        private static IWebElement cancelButton;

        private static string AddEduMessage = "Education has been added";
        private static string UpdateEduMessage = "Education as been updated";
        private static string DeleteEduMessage = "Education entry successfully removed";
        private static string AddExsistingEduMessage = "This information is already exist.";
        private static string AddInvalidEduMessage = "Please enter all the fields";
        private static string UndefinedMessage = "undefined";

        public void AddEducationAssertions()
        {
            var test = ReportManager.GetTest();
            try
            {
                Wait.WaitToBeVisible(driver, toastMessageLocator, 10);
                toastMessage = driver.FindElement(toastMessageLocator);

                string displayedMessage = toastMessage.Text;
                Console.WriteLine(displayedMessage);


                Assert.That(displayedMessage, Is.EqualTo(AddEduMessage)
                    .Or.EqualTo(AddInvalidEduMessage)
                    .Or.EqualTo(AddExsistingEduMessage));
                    

                if ((displayedMessage == AddInvalidEduMessage) ||
                    (displayedMessage == AddExsistingEduMessage))
                    
                {
                    test.Pass("Entered invalid education data : " + displayedMessage);
                    cancelButton = driver.FindElement(cancelButtonLocator);
                    cancelButton.Click();
                }
                else if (displayedMessage == AddEduMessage)
                {
                    test.Pass("Education added successfully : " + displayedMessage);

                }
                else
                {
                    test.Fail("Education add Failed");

                }
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new Exception("Toast message did not appear in the expected time.", ex);
            }
        }

        public void DeleteEducationAssertions()
        {
            var test = ReportManager.GetTest();
            try
            {
                Wait.WaitToBeVisible(driver, toastMessageLocator, 10);
                toastMessage = driver.FindElement(toastMessageLocator);

                string displayedMessage = toastMessage.Text;
                Console.WriteLine(displayedMessage);

                string deleteLangMessage = "Education entry successfully removed";

                Assert.That(displayedMessage, Is.EqualTo(deleteLangMessage));

                if (displayedMessage == deleteLangMessage)
                {
                    test.Pass("Language deleted successfully: " + displayedMessage);
                    
                }
                else
                {
                    test.Fail("Language delete failed or unexpected message: " + displayedMessage);
                }
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new Exception("Toast message did not appear in the expected time.", ex);
            }
        }



    }
}
