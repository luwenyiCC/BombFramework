using System;
using BombFramework;
using BombServer.Kernel;
using UnityEngine;
using UnityEngine.UI;

namespace HotFix_Project.UI.Login
{
    public class LoginEntiry
    {
        Button loginBtn;
        InputField account;
        InputField password;
        public void Init(string path)
        {
            GameObject go = Resources.Load(path) as GameObject;
            KeyObjectMap kom = go.GetComponent<KeyObjectMap>();
            loginBtn = kom.Get<Button>("LoginBtn");
            account = kom.Get<InputField>("Account");
            password = kom.Get<InputField>("Password");
            loginBtn.onClick .AddListener(() => {

                Debug.Log("loginBtn.onClick ");
                string acc = account.text;
                string pwd = password.text;
                Game.Instance.GetComponent<TcpComponent>().Session.Send(ProtoTools.ToBuffer(new AccPwdRequet { Account = acc, Password = pwd }, MSGID.Login));
            }   );
        }
       
        public void Awake()
        {

        }
        public void OnEnable()
        {

        }
        public void Start()
        {

        }
        public void Update()
        {

        }
        public void LateUpdate()
        {

        }
        public void OnDisable()
        {

        }
        public void OnDestroy()
        {

        }
    }
}
