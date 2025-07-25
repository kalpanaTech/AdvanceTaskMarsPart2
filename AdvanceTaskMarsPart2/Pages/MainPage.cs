using AdvanceTaskMarsPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Pages
{
    public class MainPage : Hooks
    {

        private static readonly By signInButtonLocator = By.XPath("//*[text()='Sign In']");

        private static IWebElement signInButton;

        public void LoginComponentRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, signInButtonLocator, 5);
                signInButton = driver.FindElement(signInButtonLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sign In button not located: " + ex.Message);
            }
        }

        public void ClickSignIn()
        {
            LoginComponentRendering();
            signInButton.Click();
        }
    }
}
