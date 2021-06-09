using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKacper.Extensions
{
    public static class TransformExtension 
    {
        public static void DestroyChildren(this Transform transform)
        {
            foreach(Transform child in transform)
            {
                Object.Destroy(child);
            }
        }

        public static void DestroyChild(this Transform transform, string name)
        {
            foreach(Transform child in transform)
            {
                if(child.name == name)
                {
                    Object.Destroy(child);
                    return;
                }
            }
        }

        public static GameObject CreateChild(this Transform transform)
        {
            var child = new GameObject();
            return child;
        }

        public static GameObject CreateChild(this Transform transform, string name)
        {
            var child = new GameObject();
            child.name = name;
            return child;
        }

        public static GameObject CreateChild(this Transform transform, GameObject prefab)
        {
            var child = Object.Instantiate(prefab, transform);
            return child;
        }
    }
}

