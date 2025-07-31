using AdvanceTaskMarsPart2.Model;
using AdvanceTaskMarsPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Pages
{
    public class DescriptionComponent : Hooks
    {
        private IWebElement enterDescription;
        private IWebElement saveButton;
              
        public void DescriptionComponentRendering()
        {
            try
            {
                enterDescription = driver.FindElement(By.Name("value"));
                saveButton = driver.FindElement(By.XPath("//button[@type='button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void AddOrUpdateDescription(DescriptionCredentials data)
        {
            Thread.Sleep(2000);
            DescriptionComponentRendering();
            enterDescription.Clear();

            enterDescription.SendKeys(data.textArea);
            Thread.Sleep(1000);
            saveButton.Click();
        }
       
        public void DeleteDescriptionActions(DescriptionCredentials data)
        {
            Thread.Sleep(2000);
            DescriptionComponentRendering();
            enterDescription.SendKeys(Keys.Control + "A");
            enterDescription.SendKeys(Keys.Delete);
            Thread.Sleep(1000);
            saveButton.Click();
        }
       
    }
}
