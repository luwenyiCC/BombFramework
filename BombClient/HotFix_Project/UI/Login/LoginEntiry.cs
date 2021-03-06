﻿
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
            Debug.Log("Init "+path);
            GameObject loginPanel = null;

            
            AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath+"/"+ path.ToLower());
            loginPanel = ab.LoadAsset<GameObject>(path.ToLower());

            //GameObject loginPanel = Resources.Load(path) as GameObject;
            GameObject go = Object.Instantiate(loginPanel) as GameObject;
            Transform tf = go.transform;
            UIRoot uiRoot = HotFixGame.Instance.GetComponent<UIRoot>();
            tf.SetParent(uiRoot.canvasTF);
            tf.localPosition = Vector3.zero;
            KeyObjectMap kom = go.GetComponent<KeyObjectMap>();

            
            loginBtn = kom.Get<GameObject>("Login").GetComponent<Button>();
            account = kom.Get<GameObject>("Account").GetComponent<InputField>();
            password = kom.Get<GameObject>("Password").GetComponent<InputField>();
            loginBtn.onClick .AddListener(() => {

                Debug.Log("Login.onClick ");
                //string acc = account.text;
                //string pwd = password.text;
                //Game.Instance.GetComponent<TcpComponent>().Session.Send(ProtoTools.ToBuffer(new AccPwdRequet { Account = acc, Password = pwd }, MSGID.Login));
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
