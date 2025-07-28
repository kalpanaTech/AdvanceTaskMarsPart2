using AdvanceTaskMarsPart2.Model;
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
    public class CertificationAssertions : Hooks
    {
        private static readonly By toastMessageLocator = By.XPath("//div[@class = 'ns-box-inner']");
        private static IWebElement toastMessage;

        private static readonly By cancelButtonLocator = By.XPath("//input[@value='Cancel']");
        private static IWebElement cancelButton;
       
        private static string UpdateCertMessage = " has been updated to your certification";
        private static string AddExsistingCertMessage = "This information is already exist.";
        private static string AddInvalidCertMessage = "Please enter Certification Name, Certification From and Certification Year";
        private static string UndefinedMessage = "undefined";

        public void AddCertificationAssertions(CertificationCredentials data)
        {
            var test = ReportManager.GetTest();
            try
            {
                Wait.WaitToBeVisible(driver, toastMessageLocator, 10);
                toastMessage = driver.FindElement(toastMessageLocator);

                string displayedMessage = toastMessage.Text;
                Console.WriteLine(displayedMessage);

                string AddCertMessage = data.certificate + " has been added to your certification";

                Assert.That(displayedMessage, Is.EqualTo(AddCertMessage)
                    .Or.EqualTo(AddInvalidCertMessage)
                    .Or.EqualTo(AddExsistingCertMessage));
                    

                if ((displayedMessage == AddInvalidCertMessage) ||
                    (displayedMessage == AddExsistingCertMessage))
                    
                {
                    test.Pass("Entered invalid certification data : " + displayedMessage);
                    
                }
                else if (displayedMessage == AddCertMessage)
                {
                    test.Pass("Certfication added successfully : " + displayedMessage);

                }
                else
                {
                    test.Fail("Certificate add Failed");

                }
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new Exception("Toast message did not appear in the expected time.", ex);
            }
        }

        public void DeleteCertificationAssertions(CertificationCredentials data)
        {
            var test = ReportManager.GetTest();
            try
            {
                Wait.WaitToBeVisible(driver, toastMessageLocator, 10);
                toastMessage = driver.FindElement(toastMessageLocator);

                string displayedMessage = toastMessage.Text;
                Console.WriteLine(displayedMessage);

                string deleteCertMessage = data.certificate +  " has been deleted from your certification";

                Assert.That(displayedMessage, Is.EqualTo(deleteCertMessage));

                if (displayedMessage == deleteCertMessage)
                {
                    test.Pass("Certificate deleted successfully: " + displayedMessage);
                    
                }
                else
                {
                    test.Fail("Certificate delete failed or unexpected message: " + displayedMessage);
                }
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new Exception("Toast message did not appear in the expected time.", ex);
            }
        }



    }
}
