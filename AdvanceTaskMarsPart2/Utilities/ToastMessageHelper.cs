using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Utilities
{
    public static class ToastMessageHelper
    {
        private static readonly By toastMessageLocator = By.XPath("//div[@class='ns-box-inner']");

       
        public static string VerifyToastMessage(IWebDriver driver, params string[] expectedMessages)
        {
            try
            {
                Wait.WaitToBeVisible(driver, toastMessageLocator, 10);

                var toastMessage = driver.FindElement(toastMessageLocator);
                string displayedMessage = toastMessage.Text;
                Console.WriteLine("Toast message: " + displayedMessage);

                
                Assert.That(displayedMessage, Is.AnyOf(expectedMessages));

                return displayedMessage;
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new Exception("Toast message did not appear within the expected time.", ex);
            }
        }
    }
}
