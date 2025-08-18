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
    public class ManageReceivedRequestComponents : Base
    {
        private static readonly By receivedRequestStatusLocator = By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[5]");
        private static readonly By receivedRequestAcceptButtonLocator = By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]");
        private static readonly By receivedRequestDeclineButtonLocator = By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[2]");
        private static readonly By receivedRequestCompleteButtonLocator = By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button");

        private static IWebElement receivedRequestStatus;
        private static IWebElement receivedRequestAcceptButton;
        private static IWebElement receivedRequestDeclineButton;
        private static IWebElement receivedRequestCompleteButton;


        public void ReceivedRequestStatusRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, receivedRequestStatusLocator, 5);
                receivedRequestStatus = driver.FindElement(receivedRequestStatusLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No received requests, wait for a request" + ex.Message);
            }

        }
        public void ReceivedRequestActionComponentRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, receivedRequestAcceptButtonLocator, 5);
                receivedRequestAcceptButton = driver.FindElement(receivedRequestAcceptButtonLocator);

                Wait.WaitToBeClickable(driver, receivedRequestDeclineButtonLocator, 5);
                receivedRequestDeclineButton = driver.FindElement(receivedRequestDeclineButtonLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No pending requests" + ex.Message);
            }

        }

        public void ReceivedRequestCompleteActionRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, receivedRequestCompleteButtonLocator, 5);
                receivedRequestCompleteButton = driver.FindElement(receivedRequestCompleteButtonLocator);

            }
            catch (Exception ex)
            {
                Console.WriteLine("No Completed requests from user end" + ex.Message);
            }

        }

        public string GetReceivedRequestStatus()
        {
            ReceivedRequestStatusRendering();
            return driver.FindElement(receivedRequestStatusLocator).Text;

        }

        

        public void AcceptReceivedRequestsAction()
        {
            ReceivedRequestActionComponentRendering();
            receivedRequestAcceptButton.Click();

        }
        public void DeclineReceivedRequestsAction()
        {
            ReceivedRequestActionComponentRendering();
            receivedRequestDeclineButton.Click();


        }
        public void ViewRequestsAfterCompletingFromUserEndAction()
        {
            ReceivedRequestCompleteActionRendering();
            receivedRequestCompleteButton.Click();

        }
        
    }
}
