using AdvanceTaskMarsPart2.Model;
using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.Utilities;
using CompetionTaskMars.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Steps
{
    public class CertificationSteps
    {
        ProfileCertificationOverviewComponent profileCertificationOverviewComponentObj = new ProfileCertificationOverviewComponent();
        JsonHelper jsonHelperObj = new JsonHelper();

        public void AddCertification(CertificationCredentials data)
        {

           profileCertificationOverviewComponentObj.AddCertificationActions(data);
        }
        public void DeleteEducation(CertificationCredentials data)
        {
            AddCertification(data);
            profileCertificationOverviewComponentObj.DeleteCertificationActions();
        }

    }
}
