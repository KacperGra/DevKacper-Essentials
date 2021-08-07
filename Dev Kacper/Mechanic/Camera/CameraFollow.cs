using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;

    private void FixedUpdate()
    {
        if(target != null)
        {
            float moveValue = Time.deltaTime * moveSpeed;
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveValue);
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
}
