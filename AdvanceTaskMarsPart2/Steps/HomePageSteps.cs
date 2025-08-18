using AdvanceTaskMarsPart2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Steps
{
    public class HomePageSteps
    {
        HomePage homePageObj = new HomePage();

        public void ClickOnProfileTab()
        {
            homePageObj.ProfileTabClick();
        }

        public void ClickOnUserCheckingOption()
        {
            homePageObj.UserCheckingOptionClick();
        }
        public void ClickOnManageListingsTab()
        {
            homePageObj.ManageListingsTabClick();
        }
        public void ClickOnManageRequestsTab()
        {
            homePageObj.ManageRequestsTabClick();
        }
        public void ClickOnDescriptionIcon()
        {
            homePageObj.DescriptionIconClick();
        }
    }
}
