using AdvanceTaskMarsPart2.Model;
using AdvanceTaskMarsPart2.Utilities;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Pages
{
    public class ManageListingsComponents : Hooks
    {

        private static readonly By deleteIconLocator = By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i");
        private static readonly By viewIconLocator = By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]/i");
        private static readonly By editIconLocator = By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i");
        private static readonly By yesButtonLocator = By.XPath("//button[normalize-space()='Yes']");
        private static readonly By noButtonLocator = By.XPath("//button[normalize-space()='No']");
        private static readonly By toggleContainerLocator = By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div");
        private static readonly By toggleInputLocator = By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input");

        private static readonly By searchLinkIconLocator = By.XPath("//*[@id=\"listing-management-section\"]/div[1]/div[1]/i");
        private static readonly By searchUserTextBoxLocator = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input");
        private static readonly By searchedUserLocator = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span");
        private static readonly By searchedProfileLocator = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p");
        private static readonly By sendRequestTextBoxLocator = By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/textarea");
        private static readonly By requestButtonLocator = By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[3]");
        private static readonly By confirmTradeAlertLocator = By.XPath("/html/body/div[4]/div/div[3]/button[1]");

        private static readonly By categoryRecordLocator = By.XPath("//table/tbody/tr[1]/td[2]");
        private static readonly By titleRecordLocator = By.XPath("//table/tbody/tr[1]/td[3]");
        private static readonly By addedCategoryRecordLocator = By.XPath("//div[@class='header' and text()='Category']/following-sibling::div[@class='description']");
        private static readonly By addedTitleRecordLocator = By.XPath("//span[@class='skill-title']");
        private static readonly By descriptionRecordLocator = By.XPath("//table/tbody/tr[1]/td[4]");

        private static readonly By titleLocator = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input");
        private static readonly By descriptionLocator = By.Name("description");
        private static readonly By saveButtonLocator = By.XPath("//input[@value='Save']");



        private static IWebElement deleteIcon;
        private static IWebElement editIcon;
        private static IWebElement viewIcon;
        private static IWebElement yesButton;
        private static IWebElement noButton;
        private static IWebElement toggleContainer;
        private static IWebElement toggleInput;

        private static IWebElement searchLinkIcon;
        private static IWebElement searchUserTextBox;
        private static IWebElement searchedUser;
        private static IWebElement searchedProfile;
        private static IWebElement sendRequestTextBox;
        private static IWebElement requestButton;
        private static IWebElement confirmTradeAlert;

        private static IWebElement categoryRecord;
        private static IWebElement titleRecord;
        private static IWebElement addedCategoryRecord;
        private static IWebElement addedTitleRecord;
        private static IWebElement descriptionRecord;

        private static IWebElement title;
        private static IWebElement description;
        private static IWebElement saveButton;





        // Render Methods
        public void ManageListingComponentRendering()
        {
            try
            {

                Wait.WaitToBeVisible(driver, deleteIconLocator, 5);
                deleteIcon = driver.FindElement(deleteIconLocator);

                Wait.WaitToBeVisible(driver, editIconLocator, 5);
                editIcon = driver.FindElement(editIconLocator);

                Wait.WaitToBeVisible(driver, viewIconLocator, 5);
                viewIcon = driver.FindElement(viewIconLocator);

                Wait.WaitToBeVisible(driver, toggleContainerLocator, 10);
                toggleContainer = driver.FindElement(toggleContainerLocator);

                Wait.WaitToBeVisible(driver, toggleInputLocator, 10);
                toggleInput = driver.FindElement(toggleInputLocator);

            }
            catch (Exception ex)
            {
                Console.WriteLine("No listing on page or failed to load listings, please add listings first! " + ex);
            }
        }

        public void SecrchIconRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, searchLinkIconLocator, 5);
                searchLinkIcon = driver.FindElement(searchLinkIconLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Secrch Icon not found " + ex.Message);
            }

        }
        public void SearchUserTextBoxRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, searchUserTextBoxLocator, 5);
                searchUserTextBox = driver.FindElement(searchUserTextBoxLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Search User Text Box not found " + ex.Message);
            }

        }
        public void SearchedUserRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, searchedUserLocator, 10);
                searchedUser = driver.FindElement(searchedUserLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Searched User not found " + ex.Message);
            }

        }
        public void SearchedProfileRendering()
        {
            try
            {
                Wait.WaitToBeVisible(driver, searchedProfileLocator, 5);
                searchedProfile = driver.FindElement(searchedProfileLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Searched Profile not found " + ex.Message);
            }

        }
        public void SendRequestComponentRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, sendRequestTextBoxLocator, 5);
                sendRequestTextBox = driver.FindElement(sendRequestTextBoxLocator);

                Wait.WaitToBeClickable(driver, requestButtonLocator, 5);
                requestButton = driver.FindElement(requestButtonLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Send Request Component not found " + ex.Message);
            }
        }

        public void ConfirmTradeAlertRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, confirmTradeAlertLocator, 5);
                confirmTradeAlert = driver.FindElement(confirmTradeAlertLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("confirm Trade Alert not found " + ex.Message);
            }

        }


        public void AlertWindowRendering()
        {
            Wait.WaitToBeClickable(driver, yesButtonLocator, 5);
            yesButton = driver.FindElement(yesButtonLocator);

            Wait.WaitToBeClickable(driver, noButtonLocator, 5);
            noButton = driver.FindElement(noButtonLocator);
        }
        public void ManageListingsEditPageComponentsRendering()
        {
            try
            {
                Wait.WaitToBeVisible(driver, titleLocator, 2);
                title = driver.FindElement(titleLocator);

                Wait.WaitToBeVisible(driver, descriptionLocator, 2);
                description = driver.FindElement(descriptionLocator);

                Wait.WaitToBeClickable(driver, saveButtonLocator, 2);
                saveButton = driver.FindElement(saveButtonLocator);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Manage Listings Edit Components not located: " + ex.Message);
            }
        }



        // View Actions

        public void ManageListingServiceView()
        {
            ManageListingComponentRendering();
            viewIcon.Click();
        }
        public string GetExpectedCategoryDetails()
        {
            Wait.WaitToBeVisible(driver, categoryRecordLocator, 5);
            return driver.FindElement(categoryRecordLocator).Text;
        }

        public string GetExpectedTitleDetails()
        {
            Wait.WaitToBeVisible(driver, titleRecordLocator, 5);
            return driver.FindElement(titleRecordLocator).Text;
        }
        public string GetExpectedDescriptionDetails()
        {
            Wait.WaitToBeVisible(driver, descriptionRecordLocator, 5);
            return driver.FindElement(descriptionRecordLocator).Text;
        }
        public string GetCategoryDetails()
        {
            Wait.WaitToBeVisible(driver, addedCategoryRecordLocator, 5);
            return driver.FindElement(addedCategoryRecordLocator).Text;
        }

        public string GetTitleDetails()
        {
            Wait.WaitToBeVisible(driver, addedTitleRecordLocator, 5);
            return driver.FindElement(addedTitleRecordLocator).Text;
        }

        // Edit Actions
        public void ManageListingServiceEdit(ManageListingsCredentials data)
        {
            ManageListingComponentRendering();
            editIcon.Click();

            ManageListingsEditPageComponentsRendering();
            title.Clear();
            title.SendKeys(data.serviceTitle);

            description.Clear();
            description.SendKeys(data.serviceDescription);

            saveButton.Click();
        }

        // Delete Actions
        public void ManageListingsDelete()
        {
            ManageListingComponentRendering();
            deleteIcon.Click();

            AlertWindowRendering();
            yesButton.Click();
        }

        // Send Request Actions
        public void ManageListingsSendRequest(ManageListingsCredentials data)
        {
            SecrchIconRendering();
            searchLinkIcon.Click();

            SearchUserTextBoxRendering();
            searchUserTextBox.SendKeys(data.searchUserName);

            SearchedUserRendering();
            searchedUser.Click();

            SearchedProfileRendering();
            searchedProfile.Click();

            SendRequestComponentRendering();
            sendRequestTextBox.SendKeys(data.requestMessage);
            requestButton.Click();

            ConfirmTradeAlertRendering();
            confirmTradeAlert.Click();
        }


        // Toggle Actions

        public bool ActivateToggle()
        {
            try
            {
                IWebElement toggleInput = driver.FindElement(toggleInputLocator);
                IWebElement toggleContainer = driver.FindElement(toggleContainerLocator);

                bool isChecked = toggleInput.Selected ||
                                 toggleInput.GetAttribute("aria-checked")?.Equals("true", StringComparison.OrdinalIgnoreCase) == true;

                if (!isChecked)
                {
                    toggleContainer.Click();
                    Console.WriteLine("Toggle activated.");
                    return true; 
                }
                else
                {
                    Console.WriteLine("Toggle is already active, no action taken.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error activating toggle: " + ex.Message);
                return false;
            }
        }



        public bool DeactivateToggle()
        {
            try
            {
                IWebElement toggleInput = driver.FindElement(toggleInputLocator);
                IWebElement toggleContainer = driver.FindElement(toggleContainerLocator);

                bool isChecked = toggleInput.Selected ||
                                 toggleInput.GetAttribute("aria-checked")?.Equals("true", StringComparison.OrdinalIgnoreCase) == true;

                if (isChecked)
                {
                    toggleContainer.Click();
                    Console.WriteLine("Toggle deactivated.");
                    return true; 
                }
                else
                {
                    Console.WriteLine("Toggle is already inactive, no action taken.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deactivating toggle: " + ex.Message);
                return false; 
            }
        }

    }
}
