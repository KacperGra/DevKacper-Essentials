using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKacper.Mechanic
{
    public class DestoryOnTime : MonoBehaviour
    {
        [SerializeField] public float time;

        private void Start()
        {
            Destroy(gameObject, time);
        }
    }
}

