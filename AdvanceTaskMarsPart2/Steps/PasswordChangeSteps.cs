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
    public class PasswordChangeSteps
    {
        PasswordComponent passwordComponentObj = new PasswordComponent();
        JsonHelper jsonHelperObj = new JsonHelper();

        public void ChangePassword(ChangePasswordCredentials data)
        {
            passwordComponentObj.ChangePasswordActions(data);
        }
        public void ChangePasswordWithInvalidData(ChangePasswordCredentials data)
        {
            passwordComponentObj.ChangePasswordWithInvalidData(data);
        }
    }
}
