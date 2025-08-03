using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Utilities
{
    public class Wait
    {

        public static void WaitToBeClickable(IWebDriver driver, By xpath, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(xpath));
        }
        public static void WaitToBeVisible(IWebDriver driver, By xpath, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(xpath));

        }
        public static void WaitUntilToggleState(IWebDriver driver, IWebElement toggleInput, bool expectedState, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(d => toggleInput.Selected == expectedState);
        }
    }
}
