using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.TestModel;
using AdvanceTaskMarsPart2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Process
{
    public class LoginSteps : Hooks
    {

        LoginComponent loginComponentObj = new LoginComponent();
        JsonHelper jsonHelperObj = new JsonHelper();
       
        public void LoginProcess(LoginCredentials data)
        {
            loginComponentObj.LoginAction(data);
        }
        
    }
}
