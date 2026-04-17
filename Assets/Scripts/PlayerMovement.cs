using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform cameraTransform;

    private Rigidbody _rb;
    private Vector2 _moveInput;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Onmove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();        
    }

    private void FixedUpdate()
    {
        if (cameraTransform == null) return;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * _moveInput.y + right * _moveInput.x;

        _rb.MovePosition(_rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}