using System;
using System.Collections.Generic;

namespace HotFix_Project
{
    public class TestCLRBinding
    {
        public static void RunTest()
        {
            for (int i = 0; i < 10; i++)
            {
                CLRBindingTestClass.DoSomeTest(i, i);
            }
        }
    }
}
