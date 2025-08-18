using AdvanceTaskMarsPart2.Hooks;
using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Assertions
{
    public class DescriptionAssertions : Base
    {


        private static string SaveDescriptionMessage = "Description has been saved successfully";
        private static string InvalidDescriptionMessage = "First character can only be digit or letters";
        private static string RequiredDescriptionMessage = "Please, a description is required";

        public void VerifyDescriptionAssertions()
        {
            var test = ReportManager.GetTest();

            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver,
                SaveDescriptionMessage,
                InvalidDescriptionMessage,
                RequiredDescriptionMessage);

            if (displayedMessage == SaveDescriptionMessage)
            {
                test.Pass("Description saved successfully: " + displayedMessage);
            }
            else if (displayedMessage == InvalidDescriptionMessage)
            {
                test.Pass("Invalid description entered: " + displayedMessage);

            }
            else if (displayedMessage == RequiredDescriptionMessage)
            {
                test.Pass("Description required: " + displayedMessage);

            }
            else
            {
                test.Fail("Unexpected toast message: " + displayedMessage);
            }

        }



    }
}
