using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKacper.Gameplay
{
    public class DestoryAfterTime : MonoBehaviour
    {
        [SerializeField] public float time;

        private void Start()
        {
            Destroy(gameObject, time);
        }
    }
}