using AdvanceTaskMarsPart2.Hooks;
using AdvanceTaskMarsPart2.TestModel;
using AdvanceTaskMarsPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Pages
{
    public class LoginComponent : Base
    {
        
        private static readonly By emailTextboxLocator = By.XPath("//*[@placeholder='Email address']");
        private static readonly By passwordTextboxLocator = By.XPath("//*[@placeholder='Password']");
        private static readonly By loginButtonLocator = By.XPath("//*[text()='Login']");

        
        private static IWebElement emailTextbox;
        private static IWebElement passwordTextbox;
        private static IWebElement loginButton;

        public void LoginComponentRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, emailTextboxLocator, 2);
                emailTextbox = driver.FindElement(emailTextboxLocator);

                Wait.WaitToBeClickable(driver, passwordTextboxLocator, 2);
                passwordTextbox = driver.FindElement(passwordTextboxLocator);

                Wait.WaitToBeClickable(driver, loginButtonLocator, 2);
                loginButton = driver.FindElement(loginButtonLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Login component elements not located: " + ex.Message);
            }
        }

        public void LoginAction(LoginCredentials data)
        {
            LoginComponentRendering();
            emailTextbox.SendKeys(data.email);
            passwordTextbox.SendKeys(data.password);
            loginButton.Click();
        }
    }
}
