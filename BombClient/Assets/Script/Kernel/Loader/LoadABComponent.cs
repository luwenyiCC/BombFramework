using System.Collections;
using System.Collections.Generic;
using BombServer.Kernel;
using UnityEngine;

public class LoadABComponent : BombServer.Kernel.Component
{
    public GameObject Load(string path)
    {
        Object obj = Resources.Load(path);
        GameObject go = Object.Instantiate(obj) as GameObject;
        return go;
    } 
}
