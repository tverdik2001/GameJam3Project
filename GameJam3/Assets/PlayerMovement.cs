using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



    public CharacterController controller;
    public float speed = 6f;
    public static float timeSpeed = 0f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 2f;
    public LayerMask groundMask;
    bool isGrounded;
    float tempV=0;

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(controller.isGrounded)
        {
            velocity.y = 0f;
        }
        //PlayerMovement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
       if(isGrounded)
        {
            tempV = 0;
        }
       else
        {
            tempV = 1;
        }
        Debug.Log(isGrounded);
        //Time
       timeSpeed = Mathf.Abs(z) + Mathf.Abs(x) + Mathf.Abs(velocity.y);
        if(timeSpeed <= 0)
        {
            timeSpeed = 0.2f;
        }
       Time.timeScale = Mathf.Lerp(Time.timeScale, timeSpeed, 5);
    }
}

