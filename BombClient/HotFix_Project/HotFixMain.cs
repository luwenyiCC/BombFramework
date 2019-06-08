using System;
using UnityEngine;

namespace HotFix_Project
{
    public class HotFixMain
    {
        public HotFixMain()
        {
            Debug.Log("构造函数 HotFixMain");

        }
        public void Test()
        {
            Debug.Log("test");

        }
        public void Main(string str)
        {
            Debug.Log("热更新工程启动 str="+ str);
        }
    }
}
