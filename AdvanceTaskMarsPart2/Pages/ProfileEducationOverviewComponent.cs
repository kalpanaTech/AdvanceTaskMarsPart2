using AdvanceTaskMarsPart2.Hooks;
using AdvanceTaskMarsPart2.Utilities;
using CompetionTaskMars.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Pages
{
    public class ProfileEducationOverviewComponent : Base
    {
        private static readonly By addNewEducationButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div");
        private static readonly By collegeTextBoxLocator = By.XPath("//input[@type = 'text' and @placeholder = 'College/University Name']");
        private static readonly By countryOfCollegeDropdownLocator = By.XPath("//select[@class = 'ui dropdown' and @name = 'country']");
        private static readonly By titleDropdownLocator = By.XPath("//select[@class = 'ui dropdown' and @name = 'title']");
        private static readonly By degreeTextBoxLocator = By.XPath("//input[@type = 'text' and @placeholder = 'Degree']");
        private static readonly By yearDropdownLocator = By.XPath("//select[@class = 'ui dropdown' and @name = 'yearOfGraduation']");
        private static readonly By addEducationButtonLocator = By.XPath("//input[@type = 'button' and @value = 'Add']");
        private static readonly By deleteEducationButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i");

        private static IWebElement addNewEducationButton;
        private static IWebElement collegeTextBox;
        private static IWebElement countryOfCollegeDropdown;
        private static IWebElement titleDropdown;
        private static IWebElement degreeTextBox;
        private static IWebElement yearDropdown;
        private static IWebElement addEducationButton;
        private static IWebElement deleteEducationButton;



        public void AddNewEducationButtonRendering()
        {
            Wait.WaitToBeClickable(driver, addNewEducationButtonLocator, 5);
            addNewEducationButton = driver.FindElement(addNewEducationButtonLocator);

        }

        public void AddEducationComponentsRendering()
        {
            Wait.WaitToBeClickable(driver, collegeTextBoxLocator, 2);
            collegeTextBox = driver.FindElement(collegeTextBoxLocator);

            Wait.WaitToBeClickable(driver, countryOfCollegeDropdownLocator, 2);
            countryOfCollegeDropdown = driver.FindElement(countryOfCollegeDropdownLocator);

            Wait.WaitToBeClickable(driver, titleDropdownLocator, 2);
            titleDropdown = driver.FindElement(titleDropdownLocator);

            Wait.WaitToBeClickable(driver, degreeTextBoxLocator, 2);
            degreeTextBox = driver.FindElement(degreeTextBoxLocator);

            Wait.WaitToBeClickable(driver, yearDropdownLocator, 2);
            yearDropdown = driver.FindElement(yearDropdownLocator);

            Wait.WaitToBeClickable(driver, addEducationButtonLocator, 2);
            addEducationButton = driver.FindElement(addEducationButtonLocator);


        }

        public void DeleteEducationIconRendering()
        {
            Wait.WaitToBeClickable(driver, deleteEducationButtonLocator, 3);
            deleteEducationButton = driver.FindElement(deleteEducationButtonLocator);
        }

        public void AddEducationActions(EducationCredentials data)
        {
            AddNewEducationButtonRendering();
            addNewEducationButton.Click();

            AddEducationComponentsRendering();
            collegeTextBox.SendKeys(data.college);
            countryOfCollegeDropdown.Click();
            countryOfCollegeDropdown.SendKeys(data.country);
            titleDropdown.Click();
            titleDropdown.SendKeys(data.title);
            degreeTextBox.SendKeys(data.degree);
            yearDropdown.Click();
            yearDropdown.SendKeys(data.year);
            addEducationButton.Click();


        }

        public void DeleteEducationActions()
        {
            DeleteEducationIconRendering();
            deleteEducationButton.Click();
        }
    }
}
