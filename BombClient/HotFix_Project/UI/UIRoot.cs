
using UnityEngine;
using Component = HotFix_Project.Kernel.Component;

namespace HotFix_Project
{
    public class UIRoot : Component
    {
        public Transform canvasTF;
        public GameObject canvasGO;
        public UIRoot()
        {
            GameObject go = Resources.Load<GameObject>("Canvas");
            //Debug.Log("Canvas = "+go.name);
            canvasGO = Object.Instantiate(go) as GameObject;
            //Debug.Log("canvasGO = " + canvasGO.name);

            canvasTF = canvasGO.transform;
        }
    }
}
