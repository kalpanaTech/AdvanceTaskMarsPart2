using AdvanceTaskMarsPart2.Hooks;
using AdvanceTaskMarsPart2.Steps;
using AdvanceTaskMarsPart2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Assertions
{
    public class ManageReceivedRequestAssertions : Base
    {
        private static string AcceptManageReceivedRequestMessage = "Service has been updated";
        private static string DeclineManageReceivedRequestMessage = "Service has been updated";
        private static string CompletedManageReceivedRequestMessage = "Request has been updated";

        public static string statusBeforeAccept = "Pending";
        public static string statusBeforeDecline = "Pending";
        public static string statusAfterAccept = "Accepted";
        public static string statusAfterDecline = "Declined";
        public static string statusAfterCompletionUserEnd = "Accepted";
        public static string statusAfterCompletionSenderEnd = "Completed";
        public static string statusAfterWithdrawnSenderEnd = "Withdrawn";


        public void VerifyAcceptManageReceivedRequest()
        {
            var test = ReportManager.GetTest();
            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver, AcceptManageReceivedRequestMessage);

            if (statusBeforeAccept == ManageReceivedRequestSteps.actualStatusBefore && 
                statusAfterAccept == ManageReceivedRequestSteps.actualStatusAfter && 
                displayedMessage == AcceptManageReceivedRequestMessage)
            {
                test.Pass("Request accepted successfully");
            }
            else
            {
                test.Fail("Request acceptance failed");
            }
        }
        public void VerifyDeclineManageReceivedRequest()
        {
            var test = ReportManager.GetTest();
            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver, DeclineManageReceivedRequestMessage);

            if (statusBeforeDecline == ManageReceivedRequestSteps.actualStatusBefore &&
                statusAfterDecline == ManageReceivedRequestSteps.actualStatusAfter &&
                displayedMessage == AcceptManageReceivedRequestMessage)
            {
                test.Pass("Request declined successfully");
            }
            else
            {
                test.Fail("Request decline failed");
            }
        }
        public void VerifyViewRequestsAfterCompletingFromUserEnd()
        {
            var test = ReportManager.GetTest();
            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver, CompletedManageReceivedRequestMessage);

            if (statusAfterCompletionUserEnd == ManageReceivedRequestSteps.actualStatusAfter &&
                displayedMessage == CompletedManageReceivedRequestMessage)
            {
                test.Pass("Request After Completion from User End viewed successfully");
            }
            else
            {
                test.Fail("Request After Completion from User End view failed");
            }
        }

        public void VerifyViewRequestsAfterCompletingFromSenderEnd()
        {
            var test = ReportManager.GetTest();

            if (statusAfterCompletionSenderEnd == ManageReceivedRequestSteps.actualStatusAfter)
            {
                test.Pass("Request After Completion from Sender End viewed successfully");
            }
            else
            {
                test.Fail("Request After Completion from Sender End view failed");
            }
        }

        public void VerifyViewRequestsWithdrawnFromSenderEnd()
        {
            var test = ReportManager.GetTest();

            if (statusAfterWithdrawnSenderEnd == ManageReceivedRequestSteps.actualStatusAfter)
            {
                test.Pass("Request withdrawn from Sender End viewed successfully");
            }
            else
            {
                test.Fail("Request withdrawn from Sender End view failed");
            }
        }
    }
}
