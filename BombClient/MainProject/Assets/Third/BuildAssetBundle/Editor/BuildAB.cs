using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildAB : MonoBehaviour
{
    [MenuItem("BOMB/资源打包")]
    static void BuildAllAssetBundles()
    {
        
        string dir = "UIAB";


        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);

        }
        
        //资源打包
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.iOS);

        


    }
    [MenuItem("Assets/设置资源名称")]

    static void SetAssetBundleName()
    {
        string  [] guids = Selection.assetGUIDs;
        foreach (var guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            AssetImporter ai = AssetImporter.GetAtPath(path);
            ai.assetBundleName = Path.GetFileNameWithoutExtension(path);
            //Debug.Log(path);
        }
    }
}
