using AdvanceTaskMarsPart2.Pages;
using AdvanceTaskMarsPart2.TestModel;
using AdvanceTaskMarsPart2.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Assertions
{
    public class LoginAssertions : Hooks
    {
        HomePage homePageObj = new HomePage();
        LoginComponent loginComponentObj = new LoginComponent();

        
        public void LoginAssertion()
        {
            LoginCredentials model = new LoginCredentials();
            List<LoginCredentials> Logindata = JsonHelper.ReadTestDataFromJson<LoginCredentials>("C:\\repo\\AdvanceTaskMarsPart2\\AdvanceTaskMarsPart2\\AdvanceTaskMarsPart2\\JsonTestData\\LoginData.json");
            foreach (var data in Logindata)
            {
                string userChecking = homePageObj.VerifyUserName();
                string expectedUserName = "Hi " + data.firstname;
                Assert.AreEqual(userChecking, expectedUserName, "The username provided does not match the expected username.");
            }
        }
        
    }
}
