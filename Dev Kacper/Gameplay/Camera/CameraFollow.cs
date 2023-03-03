using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed;

    private float _cameraPositionZ;

    private void Awake()
    {
        _cameraPositionZ = transform.position.z;
    }

    private void LateUpdate()
    {
        if (_target != null)
        {
            float moveValue = Time.fixedDeltaTime * _moveSpeed;
            transform.position = Vector3.MoveTowards(transform.position, _target.position, moveValue);
            transform.position = new Vector3(transform.position.x, transform.position.y, _cameraPositionZ);
        }
    }

    public void SetTarget(Transform target)
    {
        this._target = target;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        this._moveSpeed = moveSpeed;
    }
}