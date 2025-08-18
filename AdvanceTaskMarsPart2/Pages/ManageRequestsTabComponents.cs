using AdvanceTaskMarsPart2.Hooks;
using AdvanceTaskMarsPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Pages
{
    public class ManageRequestsTabComponents : Base
    {
        private static readonly By receivedRequestsLocator = By.XPath("//a[normalize-space()='Received Requests']");
        private static readonly By sentRequestsLocator = By.XPath("//a[normalize-space()='Sent Requests']");

        private static IWebElement receivedRequests;
        private static IWebElement sentRequests;

        public void ManageRequestsTabComponentsRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, receivedRequestsLocator, 2);
                receivedRequests = driver.FindElement(receivedRequestsLocator);

                Wait.WaitToBeClickable(driver, sentRequestsLocator, 2);
                sentRequests = driver.FindElement(sentRequestsLocator);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Manage requests tabs not located: " + ex.Message);
            }
        }

        public void ClickReceivedRequests()
        {
            ManageRequestsTabComponentsRendering();
            receivedRequests.Click();
        }

        public void ClickSentRequests()
        {
            ManageRequestsTabComponentsRendering();
            sentRequests.Click();
        }

    }
}
