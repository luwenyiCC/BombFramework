using System;
using UnityEngine;

public class PathTools
{
    public PathTools()
    {
    }
    static string _ILRuntimeDLL;
    public static string ILRuntimeDLL
    {
        get
        {
            if(_ILRuntimeDLL == null)
            {

#if UNITY_ANDROID
                _ILRuntimeDLL =  Application.streamingAssetsPath + "/HotFix_Project.dll";
#else
                _ILRuntimeDLL = "file:///" + Application.streamingAssetsPath + "/HotFix_Project.dll";
#endif
            }
            return _ILRuntimeDLL;

        }
    }
}
