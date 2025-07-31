using AdvanceTaskMarsPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Pages
{
    public class UserTabComponents : Hooks
    {
        private static readonly By goToProfileLocator = By.XPath("//a[normalize-space()='Go to Profile']");
        private static readonly By changePasswordLocator = By.XPath("//a[normalize-space()='Change Password']");
        private static readonly By creditsLocator = By.XPath("//a[normalize-space()='Credits :']");
        private static readonly By transactionLocator = By.XPath("//a[normalize-space()='Transaction']");
        private static readonly By accountSettingsLocator = By.XPath("//a[normalize-space()='Account Settings']");

        
        private static IWebElement goToProfile;
        private static IWebElement changePassword;
        private static IWebElement credits;
        private static IWebElement transaction;
        private static IWebElement accountSettings;

        public void UserTabComponentsRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, goToProfileLocator, 2);
                goToProfile = driver.FindElement(goToProfileLocator);

                Wait.WaitToBeClickable(driver, changePasswordLocator, 2);
                changePassword = driver.FindElement(changePasswordLocator);

                Wait.WaitToBeClickable(driver, creditsLocator, 2);
                credits = driver.FindElement(creditsLocator);

                Wait.WaitToBeClickable(driver, transactionLocator, 2);
                transaction = driver.FindElement(transactionLocator);

                Wait.WaitToBeClickable(driver, accountSettingsLocator, 2);
                accountSettings = driver.FindElement(accountSettingsLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("User menu tabs not located: " + ex.Message);
            }
        }
        public void ClickChangePassword()
        {
            UserTabComponentsRendering();
            changePassword.Click();
        }

    }
}
