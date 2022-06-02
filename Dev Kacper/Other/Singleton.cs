using System.Collections;
using UnityEngine;

namespace DevKacper
{
    public class Singleton<T> : MonoBehaviour where T : Object
    {
        private static T _instance = null;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                }

                return _instance;
            }
        }
    }
}