using AdvanceTaskMarsPart2.Model;
using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Steps
{
    public class ManageListingsSteps
    {
        ManageListingsComponents manageListingsComponentsObj = new ManageListingsComponents();
        JsonHelper jsonHelperObj = new JsonHelper();

        public static string expectedCategory;
        public static string expectedTitle;
        public static string actualCategory;
        public static string actualTitle;
        public static string expectedDescription;

        public void ViewManageListings()
        {
            expectedCategory = manageListingsComponentsObj.GetExpectedCategoryDetails();
            expectedTitle = manageListingsComponentsObj.GetExpectedTitleDetails();

            manageListingsComponentsObj.ManageListingServiceView();

            actualCategory = manageListingsComponentsObj.GetCategoryDetails();
            actualTitle = manageListingsComponentsObj.GetTitleDetails();
        }

        public void EditManageListings(ManageListingsCredentials data)
        {
            manageListingsComponentsObj.ManageListingServiceEdit(data);

            expectedTitle = manageListingsComponentsObj.GetExpectedTitleDetails();
            expectedDescription = manageListingsComponentsObj.GetExpectedDescriptionDetails();         

        }
        public void DeleteManageListings()
        {
            expectedTitle = manageListingsComponentsObj.GetExpectedTitleDetails();
            manageListingsComponentsObj.ManageListingsDelete();
        }
        public void SendManageListingsRequest(ManageListingsCredentials data)
        {
            
            manageListingsComponentsObj.ManageListingsSendRequest(data);
        }
        public bool AcivateManageListings()
        {
            return manageListingsComponentsObj.ActivateToggle(); 
        }

        public bool DeacivateManageListings()
        {
            return manageListingsComponentsObj.DeactivateToggle(); 
        }
    }
}
