using AdvanceTaskMarsPart2.Steps;
using AdvanceTaskMarsPart2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Assertions
{
    public class ManageSentRequestAssertions : Hooks
    {
        private static string WithdrawSentRequestMessage = "Request has been withdrawn";
        private static string ReviewSentRequestMessage = "Rating added, thank you!";
        private static string CompleteSentRequestMessage = "Request has been updated";

        public static string statusBeforeWithdraw = "Pending";
        public static string statusAfterWithdraw = "Withdrawn";
        public static string statusBeforeComplete = "Accepted";
        public static string statusAfterComplete = "Completed";
        public static string statusAfterReview = "Completed";
        public static string statusDecline = "Declined";

        public void VerifyWithdrawSentRequests()
        {
            var test = ReportManager.GetTest();
            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver, WithdrawSentRequestMessage);

            if (statusBeforeWithdraw == ManageSentRequestSteps.sentStatusBefore &&
                statusAfterWithdraw == ManageSentRequestSteps.sentStatusAfter &&
                displayedMessage == WithdrawSentRequestMessage)
            {
                test.Pass("Request withdrawn successfully");
            }
            else
            {
                test.Fail("Request withdraw failed");
            }

        }
        public void VerifyUpdateCompletedSentRequest()
        {
            var test = ReportManager.GetTest();
            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver, CompleteSentRequestMessage);

            if (statusBeforeComplete == ManageSentRequestSteps.sentStatusBefore &&
                statusAfterComplete == ManageSentRequestSteps.sentStatusAfter &&
                displayedMessage == CompleteSentRequestMessage)
            {
                test.Pass("Request completed successfully");
            }
            else
            {
                test.Fail("Request completion failed");
            }

        }
        public void VerifyReviewSentRequests()
        {
            var test = ReportManager.GetTest();
            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver, ReviewSentRequestMessage);

            if (statusAfterReview == ManageSentRequestSteps.sentStatusAfter &&
                displayedMessage == ReviewSentRequestMessage)
            {
                test.Pass("Request Reviewed and rated successfully");
            }
            else
            {
                test.Fail("Request review and rating failed");
            }

        }
        public void VerifyViewDeclinedSentRequests()
        {
            var test = ReportManager.GetTest();

            if (statusDecline == ManageSentRequestSteps.sentStatusAfter)
            {
                test.Pass("Request decline status viewed successfully");
            }
            else
            {
                test.Fail("Request decline status view failed");
            }
        }
    }
}
