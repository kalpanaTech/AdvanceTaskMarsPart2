using AdvanceTaskMarsPart2.Hooks;
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
    public class CertificationAssertions : Base
    {

        private static readonly By cancelButtonLocator = By.XPath("//input[@value='Cancel']");
        private static IWebElement cancelButton;


        private static string AddExistingCertMessage = "This information is already exist.";
        private static string AddInvalidCertMessage = "Please enter Certification Name, Certification From and Certification Year";


        public void AddCertificationAssertions(CertificationCredentials data)
        {
            var test = ReportManager.GetTest();


            string addCertMessage = $"{data.certificate} has been added to your certification";


            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver,
                addCertMessage,
                AddInvalidCertMessage,
                AddExistingCertMessage);

            if (displayedMessage == AddInvalidCertMessage || displayedMessage == AddExistingCertMessage)
            {
                test.Pass("Entered invalid certification data: " + displayedMessage);

            }
            else if (displayedMessage == addCertMessage)
            {
                test.Pass("Certification added successfully: " + displayedMessage);
            }
            else
            {
                test.Fail("Unexpected add certification message: " + displayedMessage);
            }
        }


        public void DeleteCertificationAssertions(CertificationCredentials data)
        {
            var test = ReportManager.GetTest();


            string deleteCertMessage = $"{data.certificate} has been deleted from your certification";


            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver, deleteCertMessage);

            if (displayedMessage == deleteCertMessage)
            {
                test.Pass("Certification deleted successfully: " + displayedMessage);
            }
            else
            {
                test.Fail("Unexpected delete certification message: " + displayedMessage);
            }
        }
    }
}
