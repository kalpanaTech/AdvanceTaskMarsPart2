using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart2.Utilities
{
    public static class ReportManager
    {
        private static ExtentTest Test;

        public static void SetTest(ExtentTest test)
        {
            Test = test;
        }

        public static ExtentTest GetTest()
        {
            return Test;
        }
    }
}
