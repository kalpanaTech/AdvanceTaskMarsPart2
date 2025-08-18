using AdvanceTaskMarsPart2.Model;
using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.Utilities;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Steps
{
    public class ManageSentRequestSteps
    {
        ManageSentRequestComponents manageSentRequestComponentsObj = new ManageSentRequestComponents();
        JsonHelper jsonHelperObj = new JsonHelper();

        public static string sentStatusBefore;
        public static string sentStatusAfter;

        public void WithdrawSentRequests()
        {
            sentStatusBefore = manageSentRequestComponentsObj.GetSentRequestStatus();
            manageSentRequestComponentsObj.WithdrawSentRequestsAction();
            sentStatusAfter = manageSentRequestComponentsObj.GetSentRequestStatus();
        }
        public void UpdateCompletedSentRequests()
        {
            sentStatusBefore = manageSentRequestComponentsObj.GetSentRequestStatus(); 
            manageSentRequestComponentsObj.UpdateCompletedSentRequestsAction();
            sentStatusAfter = manageSentRequestComponentsObj.GetSentRequestStatus();
        }
        public void ReviewSentRequests(SentRequestCredentials data)
        {
            manageSentRequestComponentsObj.ReviewSentRequestsAction(data);
            sentStatusAfter = manageSentRequestComponentsObj.GetSentRequestStatus();
        }
        public void ViewDeclinedSentRequests()
        {
            sentStatusAfter = manageSentRequestComponentsObj.GetSentRequestStatus();
        }
    }
}
