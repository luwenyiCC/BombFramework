using System;

using UnityEngine;

namespace HotFix_Project
{
    public class HotFixMain
    {
        static HotFixMain _HotFixMain;
        public HotFixMain()
        {
            Debug.Log("构造函数 HotFixMain");
            _HotFixMain = this;

        }
        public void Test()
        {
            Debug.Log("test");

        }
        FlowPathComponent flowPath;
        public void Main(string str)
        {
            Debug.Log("热更新工程启动 str="+ str);

            var obj = HotFixGame.Instance;
            Debug.Log("热更新工程启动 obj=" + obj);

            flowPath = obj.AddComponent<FlowPathComponent>();
            Debug.Log("热更新工程启动 flowPath=" + flowPath);

            obj.AddComponent<UIRoot>();
            //flowPath = HotFixGame.Instance.AddComponent<FlowPathComponent>();
            //HotFixGame.Instance.AddComponent<UIRoot>();

            //向主流程添加UI启动
            flowPath.fsm.EnState(new UIStartState());
            //LoginEntiry loginEntiry = new LoginEntiry();
            //UIRoot
            //loginEntiry.Init("LoginPanel");
        }
        public static HotFixMain Instance
        {
            get
            {
                return _HotFixMain;
            }
        }
        public void Update(float deltaTime)
        {
            //Debug.Log("deltaTime =" + deltaTime);

            flowPath.fsm.Update(deltaTime);
        }
    }
}
