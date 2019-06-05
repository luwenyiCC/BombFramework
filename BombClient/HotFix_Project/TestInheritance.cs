using System;
using System.Collections.Generic;

namespace HotFix_Project
{
    //一定要特别注意，:后面只允许有1个Unity主工程的类或者接口，但是可以有随便多少个热更DLL中的接口
    public class TestInheritance : TestClassBase
    {
        public override void TestAbstract(int gg)
        {
            UnityEngine.Debug.Log("!! TestInheritance.TestAbstract gg =" + gg);
        }

        public override void TestVirtual(string str)
        {
            base.TestVirtual(str);
            UnityEngine.Debug.Log("!! TestInheritance.TestVirtual str =" + str);
        }

        public static TestInheritance NewObject()
        {
            return new HotFix_Project.TestInheritance();
        }
    }

    //一定要特别注意，:后面只允许有1个Unity主工程的类或者接口，但是可以有随便多少个热更DLL中的接口
    public class MyTestInheritance : TestClassBase
    {
        public override void TestAbstract(int gg)
        {
            UnityEngine.Debug.Log("!! TestInheritance.TestAbstract gg =" + gg);
            UnityEngine.Debug.Log("!! TestAbstract.Value =" + Value);

        }

        public override void TestVirtual(string str)
        {
            base.TestVirtual(str);

            UnityEngine.Debug.Log("!! TestInheritance.TestVirtual str =" + str);
            UnityEngine.Debug.Log("!! TestAbstract.Value =" + Value);
        }

        public static MyTestInheritance NewObject()
        {
            return new HotFix_Project.MyTestInheritance();
        }
    }
}
