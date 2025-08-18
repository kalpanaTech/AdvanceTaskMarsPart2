using AdvanceTaskMarsPart2.Assertions;
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
    public class EducationSteps
    {
        ProfileEducationOverviewComponent profileEducationOverviewComponentObj = new ProfileEducationOverviewComponent();
       
        JsonHelper jsonHelperObj = new JsonHelper();
        public void AddEducation(EducationCredentials data)
        {
           
            profileEducationOverviewComponentObj.AddEducationActions(data);
        }
        public void DeleteEducation(EducationCredentials data)
        {
            AddEducation(data);
            profileEducationOverviewComponentObj.DeleteEducationActions();
        }
    }

}
