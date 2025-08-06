using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Steps
{
    public class ManageReceivedRequestSteps
    {
        ManageReceivedRequestComponents manageReceivedRequestComponentsObj = new ManageReceivedRequestComponents();
        JsonHelper jsonHelperObj = new JsonHelper();

        public static string actualStatusBefore;
        public static string actualStatusAfter;
        public void AcceptReceivedRequests()
        {
            actualStatusBefore = manageReceivedRequestComponentsObj.GetReceivedRequestStatus(); 
            manageReceivedRequestComponentsObj.AcceptReceivedRequestsAction();
            actualStatusAfter = manageReceivedRequestComponentsObj.GetReceivedRequestStatus();
        }

        public void DeclineReceivedRequests()
        {
            actualStatusBefore = manageReceivedRequestComponentsObj.GetReceivedRequestStatus(); 
            manageReceivedRequestComponentsObj.DeclineReceivedRequestsAction();
            actualStatusAfter = manageReceivedRequestComponentsObj.GetReceivedRequestStatus();
        }
        public void ViewRequestsAfterCompletingFromUserEnd()
        {
            actualStatusAfter = manageReceivedRequestComponentsObj.GetReceivedRequestStatus(); 
            manageReceivedRequestComponentsObj.ViewRequestsAfterCompletingFromUserEndAction();
        }
        public void ViewRequestsAfterCompletingFromSenderEnd()
        {
            actualStatusAfter = manageReceivedRequestComponentsObj.GetReceivedRequestStatus(); 
        }

        public void ViewRequestsWithdrawnFromSenderEnd()
        {
            actualStatusAfter = manageReceivedRequestComponentsObj.GetReceivedRequestStatus(); 
        }
    }
}
