using System;

using SequentialFSM;
using UnityEngine;

namespace HotFix_Project
{
    public class UIStartState : IState
    {
        public UIStartState()
        {
            Debug.Log("UIStartState()");

        }
        LoginEntiry loginEntiry;
        public void OnEnter()
        {
            Debug.Log("IState.OnEnter()");
            loginEntiry = new LoginEntiry();

            loginEntiry.Init("LoginPanel");
        }

        public bool OnExecute(float deltaTime)
        {
            //throw new NotImplementedException();
            //loginEntiry(deltaTime);
            return false;
        }

        public void OnExit()
        {
            //throw new NotImplementedException();
        }
    }
}
