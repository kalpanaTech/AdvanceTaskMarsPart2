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
    public class DescriptionSteps
    {
        DescriptionComponent descriptionComponentObj = new DescriptionComponent();
        JsonHelper jsonHelperObj = new JsonHelper();
        public void AddDescription(DescriptionCredentials data)
        {
            
            descriptionComponentObj.AddOrUpdateDescription(data);
        }

        public void UpdateDescription(DescriptionCredentials data)
        {
            descriptionComponentObj.AddOrUpdateDescription(data);

        }

        public void DeleteDescription(DescriptionCredentials data)
        {
            descriptionComponentObj.DeleteDescriptionActions(data);
        }

    }
}
