using UnityEngine;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;
namespace BombServer.Kernel
{


    [Serializable]
    public class KeyObjectData
    {
        public string key;
        public Object gameObject;
    }
    public class KeyObjectMap : MonoBehaviour, ISerializationCallbackReceiver
    {
        public List<KeyObjectData> data = new List<KeyObjectData>();
        private readonly Dictionary<string, Object> dict = new Dictionary<string, Object>();

        /// <summary>
        /// Ons the after deserialize.
        /// 反序列化后触发方法
        /// </summary>
        public void OnAfterDeserialize()
        {
            //Debug.Log("OnAfterDeserialize");
            dict.Clear();
            foreach (KeyObjectData item in data)
            {
                if (!dict.ContainsKey(item.key))
                {
                    dict.Add(item.key, item.gameObject);
                }
            }
        }
        /// <summary>
        /// Ons the before serialize.
        /// 序列化前触发方法
        /// </summary>
        public void OnBeforeSerialize()
        {
            foreach (KeyObjectData item in data)
            {
                if (item.gameObject != null & string.IsNullOrEmpty(item.key))
                {
                    item.key =  item.gameObject.name;
                }
            }

        }

        public T Get<T>(string key) where T : class
        {
            Object dictGo;
            if (!dict.TryGetValue(key, out dictGo))
            {
                return null;
            }
            return dictGo as T;
        }

        public Object GetObject(string key)
        {
            Object dictGo;
            if (!dict.TryGetValue(key, out dictGo))
            {
                return null;
            }
            return dictGo;
        }
    }
}