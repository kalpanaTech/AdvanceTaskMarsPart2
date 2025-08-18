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
    public class ProfileMenuTabsComponents : Base
    {
        private static readonly By languagesTabLocator = By.XPath("//A[@class='item active'][text()='Languages']");
        private static readonly By skillsTabLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]");
        private static readonly By educationTabLocator = By.XPath("//A[@class = 'item'][text() = 'Education']");
        private static readonly By educationDeleteButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i");
        private static readonly By certificationTabLocator = By.XPath("//A[@class = 'item'][text() = 'Certifications']");
        private static readonly By certificationDeleteButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]/i");

        private static IWebElement languagesTab;
        private static IWebElement skillsTab;
        private static IWebElement educationTab;
        private static IWebElement educationDeleteButton;
        private static IWebElement certificationsTab;
        private static IWebElement certificationDeleteButton;

        public void ProfileTabComponentsRendering()
        {
            try
            {
                Wait.WaitToBeClickable(driver, languagesTabLocator, 2);
                languagesTab = driver.FindElement(languagesTabLocator);

                Wait.WaitToBeClickable(driver, skillsTabLocator, 2);
                skillsTab = driver.FindElement(skillsTabLocator);

                Wait.WaitToBeClickable(driver, educationTabLocator, 2);
                educationTab = driver.FindElement(educationTabLocator);

                Wait.WaitToBeClickable(driver, certificationTabLocator, 2);
                certificationsTab = driver.FindElement(certificationTabLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Profile tabs not located: " + ex.Message);
            }
        }

        public void ClickEducationTab()
        {
            ProfileTabComponentsRendering();
            educationTab.Click();
        }

        public void ClickCertificationTab()
        {
            ProfileTabComponentsRendering();
            certificationsTab.Click();
        }
        public void EducationDeleteButtonRendering()
        {
            try
            {
                Wait.WaitToBeVisible(driver, educationDeleteButtonLocator, 3);

                educationDeleteButton = driver.FindElement(educationDeleteButtonLocator);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No existing records");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Button Not Located");
            }
        }

        public void CertificationDeleteButtonRendering()
        {
            try
            {
                Wait.WaitToBeVisible(driver, certificationDeleteButtonLocator, 3);

                certificationDeleteButton = driver.FindElement(certificationDeleteButtonLocator);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No existing records");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Button Not Located");
            }
        }

        public void RemoveAddedEducationDetails()
        {

            IList<IWebElement> educationDeleteButton;
            do
            {
                EducationDeleteButtonRendering();
                educationDeleteButton = driver.FindElements(educationDeleteButtonLocator);

                if (educationDeleteButton.Count > 0)
                {

                    Wait.WaitToBeClickable(driver, educationDeleteButtonLocator, 3);
                    try
                    {
                        educationDeleteButton[0].Click();
                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("education Delete Button not located or couldn't be clicked: " + ex.Message);
                    }
                    driver.Navigate().Refresh();
                    ClickEducationTab();
                    Thread.Sleep(2000);

                }
            } while (educationDeleteButton.Count > 0);
        }
        public void RemoveAddedCertificationDetails()
        {
            IList<IWebElement> certificationDeleteButton;
            do
            {
                CertificationDeleteButtonRendering();
                certificationDeleteButton = driver.FindElements(certificationDeleteButtonLocator);

                if (certificationDeleteButton.Count > 0)
                {

                    Wait.WaitToBeClickable(driver, certificationDeleteButtonLocator, 2);
                    try
                    {
                        certificationDeleteButton[0].Click();
                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("education Delete Button not located or couldn't be clicked: " + ex.Message);
                    }
                    driver.Navigate().Refresh();
                    ClickCertificationTab();
                    Thread.Sleep(2000);

                }
            } while (certificationDeleteButton.Count > 0);
        }



    }

}
