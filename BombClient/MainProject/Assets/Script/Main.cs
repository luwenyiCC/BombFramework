using System.Collections;
using System.Collections.Generic;
using BombServer.Kernel;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    ILRMain ilrMain;
    void Start()
    {
        //Game.Instance.AddComponent<SystemEvent>();
        Game.Instance.AddComponent<LoadABComponent>();
        ilrMain = Game.Instance.AddComponent<ILRMain>();
        Game.Instance.AddComponent<TcpComponent>();


        
    }

    // Update is called once per frame
    void Update()
    {

        ilrMain?.Update(Time.deltaTime);
    }
}
