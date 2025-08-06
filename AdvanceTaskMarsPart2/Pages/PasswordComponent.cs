using AdvanceTaskMarsPart2.Utilities;
using AdvanceTaskMarsPart2.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AdvanceTaskMarsPart2.Hooks;

namespace AdvanceTaskMarsPart2.Pages
{
    public class PasswordComponent : Base
    {
        private static readonly By currentPasswordTextBoxLocator = By.XPath("//input[@name='oldPassword']");
        private static readonly By newPasswordTextBoxLocator = By.XPath("//input[@name='newPassword']");
        private static readonly By confirmPasswordTextBoxLocator = By.XPath("//input[@name='confirmPassword']");
        private static readonly By passwordSaveButtonLocator = By.XPath("/html/body/div[4]/div/div[2]/form/div[4]/button");

        private static IWebElement currentPasswordTextBox;
        private static IWebElement newPasswordTextBox;
        private static IWebElement confirmPasswordTextBox;
        private static IWebElement passwordSaveButton;

        public void ChangePasswordComponentsRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, currentPasswordTextBoxLocator, 2);
                currentPasswordTextBox = driver.FindElement(currentPasswordTextBoxLocator);

                Wait.WaitToBeClickable(driver, newPasswordTextBoxLocator, 2);
                newPasswordTextBox = driver.FindElement(newPasswordTextBoxLocator);

                Wait.WaitToBeClickable(driver, confirmPasswordTextBoxLocator, 2);
                confirmPasswordTextBox = driver.FindElement(confirmPasswordTextBoxLocator);

                Wait.WaitToBeClickable(driver, passwordSaveButtonLocator, 2);
                passwordSaveButton = driver.FindElement(passwordSaveButtonLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Password components not located: " + ex.Message);
            }
        }

        public void ChangePasswordActions(ChangePasswordCredentials data)
        {
            Thread.Sleep(2000);
            ChangePasswordComponentsRendering();
            currentPasswordTextBox.SendKeys(data.currentPassword);
            newPasswordTextBox.SendKeys(data.newPassword);
            confirmPasswordTextBox.SendKeys(data.confirmPassword);
            Thread.Sleep(1000);
            passwordSaveButton.Click();
        }

        public void ChangePasswordWithInvalidData(ChangePasswordCredentials data)
        {
            Thread.Sleep(2000);
            ChangePasswordComponentsRendering();

            currentPasswordTextBox.Clear();
            currentPasswordTextBox.SendKeys(data.currentPassword);

            newPasswordTextBox.Clear();
            newPasswordTextBox.SendKeys(data.newPassword);

            confirmPasswordTextBox.Clear();
            confirmPasswordTextBox.SendKeys(data.confirmPassword);
            Thread.Sleep(1000);
            passwordSaveButton.Click();
            
            


        }
    }
}
