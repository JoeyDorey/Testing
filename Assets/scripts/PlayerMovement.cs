using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Crouch
    float originalHeight;
    public float reducedHeight;

    public CharacterController controller;


    public float walkSpeed = 12f;
    public float sprintSpeed = 24f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundmask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalHeight = controller.height;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * walkSpeed * Time.deltaTime);
        
        //Sprint function
        if (Input.GetKey(KeyCode.LeftShift))

            controller.Move(move * sprintSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Falling Gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        //crouch function
        if (Input.GetKeyDown(KeyCode.LeftControl))
            crouch();
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            goUp();
    }

    
    void crouch()
    {
        controller.height = reducedHeight;
    }

    void goUp()
    {
        controller.height = originalHeight;
    }

}
