using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBall : MonoBehaviour
{
    //adjust as needed
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotationSpeed = 5f; 


    private Vector3 inputDirection;
    private float desiredRotation = 0f;
    void Start()
    {
        
        // Get the Rigidbody component attached to the GameObject.
        rb = GetComponent<Rigidbody>();
        rb.drag = 5f; 
        rb.angularDrag = 5f; 
    }

    void Update()
    {
        HandleMovementInput();
        HandleRotation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        inputDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
    }

    void HandleRotation()
    {
        if (inputDirection != Vector3.zero)
        {
            desiredRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
        }

        Quaternion targetRotation = Quaternion.Euler(0, desiredRotation, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = inputDirection * moveSpeed;
    }
}