using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction moveAction;

    public float walkSpeed = 1;
    public float turnSpeed = 20;

    Rigidbody rb;
    Animator anim;
    Vector3 movement;
    Quaternion rotation = Quaternion.identity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        moveAction.Enable();
    }

    void FixedUpdate()
    {
        var pos = moveAction.ReadValue<Vector2>();

        float horizontal = pos.x;
        float vertical = pos.y;
        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();
        
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        anim.SetBool("WALK", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredForward);

        rb.MoveRotation(rotation);
        rb.MovePosition(rb.position + movement * walkSpeed * Time.deltaTime);
    }

    void Update()
    {
        
    }
}
