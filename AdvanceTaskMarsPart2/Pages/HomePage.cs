using AdvanceTaskMarsPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Pages
{
    public class HomePage : Hooks
    {

        private static readonly By userCheckingLocator = By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span");
        private static readonly By profileTabLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        private static readonly By manageListingsLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]");
        private static readonly By manageRequestsLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]");
        private static readonly By descriptionLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i");
        
        

        private static IWebElement userChecking;
        private static IWebElement profileTab;
        private static IWebElement manageListings;
        private static IWebElement manageRequests;
        private static IWebElement description;


        public void UserCheckingComponentRendering()
        {
            try
            {
                Wait.WaitToBeVisible(driver, userCheckingLocator, 5);
                userChecking = driver.FindElement(userCheckingLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("User name label not located: " + ex.Message);
            }
        }

       
        public void ProfileTabComponentRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, profileTabLocator, 3);
                profileTab = driver.FindElement(profileTabLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Profile tab not located: " + ex.Message);
            }
        }
        public void ManageListingsComponentRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, manageListingsLocator, 3);
                manageListings = driver.FindElement(manageListingsLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Manage Listings tab not located: " + ex.Message);
            }

        }
        public void ManageRequestsComponentRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, manageRequestsLocator, 3);
                manageRequests = driver.FindElement(manageRequestsLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Manage Requests component not located: " + ex.Message);
            }

        }
        public void DescriptionComponentRendering()
        {
            try
            {
                Wait.WaitToBeVisible(driver, descriptionLocator, 3);
                description = driver.FindElement(descriptionLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Description component not located: " + ex.Message);
            }

        }
        public string VerifyUserName()
        {
            UserCheckingComponentRendering();
            return userChecking.Text;
        }

        public void ProfileTabClick()
        {
            ProfileTabComponentRendering();
            profileTab.Click();
        }

        public void UserCheckingOptionClick()
        {
            UserCheckingComponentRendering();
            userChecking.Click();
        }
        public void ManageListingsTabClick()
        {
            ManageListingsComponentRendering();
            manageListings.Click();
        }
        public void ManageRequestsTabClick()
        {
            ManageRequestsComponentRendering();
            manageRequests.Click();
        }
        public void DescriptionIconClick()
        {
            DescriptionComponentRendering();
            description.Click();
        }



    }
    }
