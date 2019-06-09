using System;
using BombFramework;
using BombServer.Kernel;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace HotFix_Project
{
    public class LoginEntiry
    {
        Button loginBtn;
        InputField account;
        InputField password;
        public void Init(string path)
        {
            GameObject loginPanel = Resources.Load<GameObject>(path);
            GameObject go = Object.Instantiate(loginPanel) as GameObject;

            KeyObjectMap kom = go.GetComponent<KeyObjectMap>();

            loginBtn = kom.Get<GameObject>("LoginBtn").GetComponent<Button>();
            account = kom.Get<GameObject>("Account").GetComponent<InputField>();
            password = kom.Get<GameObject>("Password").GetComponent<InputField>();
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
