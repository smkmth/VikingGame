using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VerticalAndHorizontalMovement : MonoBehaviour
{



    public float MovementSpeed;
    public float AirMovementSpeed;
    public float JumpForce;
    public float DistanceToGround;


    private Vector3 movepos;
    private Rigidbody rb;

    private float currentMoveSpeed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
    }


    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, DistanceToGround + 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {

            transform.position += movepos + transform.forward * Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;

        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            
            transform.position += movepos + transform.right * Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;

        }

        if (Input.GetButtonDown("Jump"))
        {
            movepos.y = 1;
            rb.AddForce(movepos * JumpForce, ForceMode.Impulse);
        }
        else
        {
            movepos.y = 0;
        }

        if (isGrounded())
        {
            currentMoveSpeed = MovementSpeed;
            rb.drag = 10.0f;
        }
        else
        {
            rb.drag = 0.0f;
            currentMoveSpeed = AirMovementSpeed;
        }
    }
}
