using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    private const float MinMoveToRotate = 0.01f;

    [Header("References")]
    [SerializeField] private Rigidbody2D _rigidbody = null;

    [Header("Settings")]
    [SerializeField] private float _movementSpeed = 400f;

    [SerializeField] private float _movementSmoothing = 0.05f;

    private Vector3 _lastMove;
    private Vector3 _currentVelocity;

    private void Awake()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
    }

    public void Move(Vector3 move)
    {
        _lastMove = move * _movementSpeed;
        _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, _lastMove, ref _currentVelocity, _movementSmoothing);
        Rotate();
    }

    public void Move(float x, float y)
    {
        Move(new Vector2(x, y));
    }

    public void Rotate()
    {
        if (_lastMove.x > MinMoveToRotate)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (_lastMove.x < -MinMoveToRotate)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    public float GetMovementSpeed()
    {
        return _movementSpeed;
    }

    public void SetMovementSpeed(float speed)
    {
        _movementSpeed = speed;
    }
}