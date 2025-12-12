using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction moveAction;

    public float walkSpeed;
    public float turnSpeed;

    Rigidbody rb;
    Vector3 movement;
    Quaternion rotation = Quaternion.identity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction.Enable();
    }

    void FixedUpdate()
    {
        var pos = moveAction.ReadValue<Vector2>();

        float horizontal = pos.x;
        float vertical = pos.y;
        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredForward);

        rb.MoveRotation(rotation);
        rb.MovePosition(rb.position + movement * walkSpeed * Time.deltaTime);
    }

    void Update()
    {
        
    }
}
