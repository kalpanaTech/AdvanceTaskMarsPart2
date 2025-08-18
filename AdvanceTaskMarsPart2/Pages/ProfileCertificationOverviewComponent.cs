using AdvanceTaskMarsPart2.Hooks;
using AdvanceTaskMarsPart2.Model;
using AdvanceTaskMarsPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Pages
{

    public class ProfileCertificationOverviewComponent : Base
    {
        private static readonly By addNewCertificationButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div");
        private static readonly By certificateTextBoxLocator = By.XPath("//input[@type = 'text' and @placeholder = 'Certificate or Award' and @name = 'certificationName']");
        private static readonly By certifiedFromTextBoxLocator = By.XPath("//input[@type = 'text' and @placeholder = 'Certified From (e.g. Adobe)' and @name = 'certificationFrom']");
        private static readonly By certificationYearDropdownLocator = By.XPath("//select[@class = 'ui fluid dropdown' and @name = 'certificationYear']");
        private static readonly By addCertificationButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]");
        private static readonly By deleteCertificationButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]/i");

        private static IWebElement addNewCertificationButton;
        private static IWebElement certificateTextBox;
        private static IWebElement certifiedFromTextBox;
        private static IWebElement certificationYearDropdown;
        private static IWebElement addCertificationButton;
        private static IWebElement deleteCertificationButton;

        public void AddNewCertificationButtonsRendering()
        {
            Wait.WaitToBeClickable(driver, addNewCertificationButtonLocator, 5);
            addNewCertificationButton = driver.FindElement(addNewCertificationButtonLocator);
        }

        public void AddCertificationComponentsRendering()
        {
            Wait.WaitToBeClickable(driver, certificateTextBoxLocator, 2);
            certificateTextBox = driver.FindElement(certificateTextBoxLocator);

            Wait.WaitToBeClickable(driver, certifiedFromTextBoxLocator, 2);
            certifiedFromTextBox = driver.FindElement(certifiedFromTextBoxLocator);

            Wait.WaitToBeClickable(driver, certificationYearDropdownLocator, 2);
            certificationYearDropdown = driver.FindElement(certificationYearDropdownLocator);

            Wait.WaitToBeClickable(driver, addCertificationButtonLocator, 2);
            addCertificationButton = driver.FindElement(addCertificationButtonLocator);
        }

        public void DeleteCertificationIconRendering()
        {
            Wait.WaitToBeClickable(driver, deleteCertificationButtonLocator, 3);
            deleteCertificationButton = driver.FindElement(deleteCertificationButtonLocator);
        }

        public void AddCertificationActions(CertificationCredentials data)
        {
            AddNewCertificationButtonsRendering();
            addNewCertificationButton.Click();

            AddCertificationComponentsRendering();
            certificateTextBox.SendKeys(data.certificate);
            certifiedFromTextBox.SendKeys(data.certifiedFrom);
            certificationYearDropdown.Click();
            certificationYearDropdown.SendKeys(data.certificationYear);
            addCertificationButton.Click();

        }

        public void DeleteCertificationActions()
        {
            DeleteCertificationIconRendering();
            deleteCertificationButton.Click();

        }


    }
}
