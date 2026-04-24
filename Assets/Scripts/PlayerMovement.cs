using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 5f;
    [SerializeField] private Transform cameraTransform;

    private Rigidbody _rb;
    private Vector2 _moveInput;
    private bool _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();        
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed == false || _isGrounded == false)
            return;

        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision) => _isGrounded = true;
    void OnCollisionExit(Collision collision) => _isGrounded = false;

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