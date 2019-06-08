using System.Collections;
using System.Collections.Generic;
using BombServer.Kernel;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Game.Instance.AddComponent<SystemEvent>();
        Game.Instance.AddComponent<ILRMain>();
        Game.Instance.AddComponent<TcpComponent>();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
}
