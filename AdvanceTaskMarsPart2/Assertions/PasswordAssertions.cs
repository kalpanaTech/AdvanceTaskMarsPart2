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
    public class PasswordAssertions : Base
    {
       
        private static string PasswordChangeSuccessMessage = "Password Changed Successfully";
        private static string PasswordDoesNotMatchMessage = "Passwords does not match";
        private static string PasswordEmptyFeildsMessage = "Please fill all the details before Submit";
        private static string PasswordInvalidMessage = "Passwords required at least 6 characters";
        private static string PasswordVerificationFailedMessage = "Password verification failed";


        public void VerifyPasswordChangeAssertions()
        {
            var test = ReportManager.GetTest();

            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver,
                PasswordChangeSuccessMessage,
                PasswordDoesNotMatchMessage,
                PasswordEmptyFeildsMessage,
                PasswordInvalidMessage,
                PasswordVerificationFailedMessage
            );


            if (displayedMessage == PasswordChangeSuccessMessage)
            {
                test.Pass("Password changed successfully: " + displayedMessage);
            }
            else if (displayedMessage == PasswordDoesNotMatchMessage)
            {
                test.Pass("Passwords do not match: " + displayedMessage);
            }
            else if (displayedMessage == PasswordEmptyFeildsMessage)
            {
                test.Pass("Password fields are empty: " + displayedMessage);
            }
            else if (displayedMessage == PasswordInvalidMessage)
            {
                test.Pass("Password is invalid (less than 6 characters): " + displayedMessage);
            }
            else if (displayedMessage == PasswordVerificationFailedMessage)
            {
                test.Pass("Password verification failed: " + displayedMessage);
            }
            else
            {
                test.Fail("Unexpected toast message: " + displayedMessage);
            }
        }


    }
    
}
