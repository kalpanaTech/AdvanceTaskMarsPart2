using AdvanceTaskMarsPart2.Hooks;
using AdvanceTaskMarsPart2.Model;
using AdvanceTaskMarsPart2.Utilities;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Pages
{
    public class ManageSentRequestComponents : Base
    {
        private static readonly By sentRequestStatusLocator = By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[5]");
        private static readonly By sentRequestWithdrawButtonLocator = By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button");
        private static readonly By sentRequestCompletedButtonLocator = By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button");
        private static readonly By sentRequestReviewButtonLocator = By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button");
        private static readonly By sentRequestReviewTextBoxLocator = By.XPath("//*[@id=\"reviewCommentInput\"]");
        private static readonly By sentRequestReviewSaveButtonLocator = By.XPath("/html/body/div[2]/div/div[2]/div/div[4]/div");
        private static readonly By sentRequestReviewCloseButtonLocator = By.XPath("/html/body/div[2]/div/div[2]/div/div[4]/button");
        private static readonly By sentRequestReviewRating1Locator = By.XPath("//*[@id=\"communicationRating\"]/i[2]");
        private static readonly By sentRequestReviewRating2Locator = By.XPath("//*[@id=\"serviceRating\"]/i[1]");
        private static readonly By sentRequestReviewRating3Locator = By.XPath("//*[@id=\"recommendRating\"]/i[3]");

        private static IWebElement sentRequestStatus;
        private static IWebElement sentRequestWithdrawButton;
        private static IWebElement sentRequestCompletedButton;
        private static IWebElement sentRequestReviewTextBox;
        private static IWebElement sentRequestReviewSaveButton;
        private static IWebElement sentRequestReviewCloseButton;
        private static IWebElement sentRequestReviewButton;
        private static IWebElement sentRequestReviewRating1;
        private static IWebElement sentRequestReviewRating2;
        private static IWebElement sentRequestReviewRating3;

        public void SentRequestStatusRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, sentRequestStatusLocator, 5);
                sentRequestStatus = driver.FindElement(sentRequestStatusLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No sent requests, please send a request" + ex.Message);
            }

        }
        public void SentRequestWithdrawButtonRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, sentRequestWithdrawButtonLocator, 5);
                sentRequestWithdrawButton = driver.FindElement(sentRequestWithdrawButtonLocator);

            }
            catch (Exception ex)
            {
                Console.WriteLine("No pending sent requests" + ex.Message);
            }

        }
        public void SentRequestCompletedButtonRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, sentRequestCompletedButtonLocator, 5);
                sentRequestCompletedButton = driver.FindElement(sentRequestCompletedButtonLocator);

            }
            catch (Exception ex)
            {
                Console.WriteLine("No completed requests" + ex.Message);
            }

        }
        public void SentRequestReviewButtonRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, sentRequestReviewButtonLocator, 5);
                sentRequestReviewButton = driver.FindElement(sentRequestReviewButtonLocator);

            }
            catch (Exception ex)
            {
                Console.WriteLine("No requests for review" + ex.Message);
            }

        }
        public void SentRequestReviewWindowRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, sentRequestReviewTextBoxLocator, 5);
                sentRequestReviewTextBox = driver.FindElement(sentRequestReviewTextBoxLocator);

                Wait.WaitToBeClickable(driver, sentRequestReviewSaveButtonLocator, 5);
                sentRequestReviewSaveButton = driver.FindElement(sentRequestReviewSaveButtonLocator);

                Wait.WaitToBeClickable(driver, sentRequestReviewCloseButtonLocator, 5);
                sentRequestReviewCloseButton = driver.FindElement(sentRequestReviewCloseButtonLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Review window components not located" + ex.Message);
            }

        }

        public string GetSentRequestStatus()
        {
            SentRequestStatusRendering();
            return driver.FindElement(sentRequestStatusLocator).Text;

        }

        public void WithdrawSentRequestsAction()
        {
            SentRequestWithdrawButtonRendering();
            sentRequestWithdrawButton.Click();
        }
        public void UpdateCompletedSentRequestsAction()
        {
            SentRequestCompletedButtonRendering();
            sentRequestCompletedButton.Click();
        }
        public void ReviewSentRequestsAction(SentRequestCredentials data)
        {
            SentRequestReviewButtonRendering();
            sentRequestReviewButton.Click();

            SentRequestReviewWindowRendering();
            sentRequestReviewTextBox.SendKeys(data.reviewMessage);
            sentRequestReviewRating1.Click();
            sentRequestReviewRating2.Click();
            sentRequestReviewRating3.Click();
            sentRequestReviewSaveButton.Click();


        }
    }
}
