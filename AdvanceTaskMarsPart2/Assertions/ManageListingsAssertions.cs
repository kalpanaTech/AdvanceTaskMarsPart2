using AdvanceTaskMarsPart2.Hooks;
using AdvanceTaskMarsPart2.Model;
using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.Steps;
using AdvanceTaskMarsPart2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Assertions
{
    public class ManageListingsAssertions : Base
    {
        
        private static string DeleteManageListingsFailedMessage = "Unable to delete listing. Pending or Accepted skill trade requests exist.";
        private static string RequestSentMessage = "Request sent";
        private static string ServiceActivatedMessage = "Service has been activated";
        private static string ServiceDeactivatedMessage = "Service has been deactivated";


        public void VerifyViewManageListings()
        {
            var test = ReportManager.GetTest();

            if (ManageListingsSteps.expectedCategory == ManageListingsSteps.actualCategory &&
                ManageListingsSteps.expectedTitle == ManageListingsSteps.actualTitle)
            {
                test.Pass("View Manage Listings success");
            }
            else
            {
                test.Fail($"View Manage Listings Failed");
            }
        }

        public void VerifyEditManageListings(ManageListingsCredentials data)
        {
            var test = ReportManager.GetTest();

            if (ManageListingsSteps.expectedTitle == data.serviceTitle &&
                ManageListingsSteps.expectedDescription == data.serviceDescription)
            {
                test.Pass("Edit Manage Listings success");
            }
            else
            {
                test.Fail("Edit Manage Listings Failed");
            }
        }
        public void VerifyManageListingsDelete()
        {
            var test = ReportManager.GetTest();

            // Build the expected toast message dynamically using the title
            string deleteManageListingsMessage = ManageListingsSteps.expectedTitle + " has been deleted";

            // Get the displayed toast message
            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver, deleteManageListingsMessage);

            if (displayedMessage == deleteManageListingsMessage)
            {
                test.Pass("Manage Listing deleted successfully: " + displayedMessage);
            }
            else if (displayedMessage == DeleteManageListingsFailedMessage)
            {
                test.Pass("Manage Listing could not be deleted due to existing pending or accepted skill trade requests.");
            }
            else
            {
                test.Fail("Unexpected delete manage listing message: " + displayedMessage);
            }
        }

            public void VerifyManageListingsSendRequest()
            {
                var test = ReportManager.GetTest();

                string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver, RequestSentMessage);

                if (displayedMessage == RequestSentMessage)
                {
                    test.Pass("Request sending successfull: " + displayedMessage);
                    
                }
                
                else
                {
                    test.Fail("Request sending unsuccessfull " + displayedMessage);
                }
            }

        public void VerifyManageListingsToggleActions()
        {
            var test = ReportManager.GetTest();

            string displayedMessage = ToastMessageHelper.VerifyToastMessage(driver, ServiceActivatedMessage, ServiceDeactivatedMessage);

            if (displayedMessage == ServiceActivatedMessage)
            {
                test.Pass("Service Activation successfull: " + displayedMessage);

            }
            else if (displayedMessage == ServiceDeactivatedMessage)
            {
                test.Pass("Service Deactivation successfully: " + displayedMessage);
            }

            else
            {
                test.Fail("Undefined message " + displayedMessage);
            }
        }
    }
}
