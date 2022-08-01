using System.Collections;
using UnityEngine;

namespace DevKacper
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance = null;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    // If object was not found on scene creating new one
                    if (_instance == null)
                    {
                        GameObject instanceObject = new GameObject(typeof(T).Name);
                        _instance = instanceObject.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }
    }
}