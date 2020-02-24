using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    float x;
    float z;
    public float jumpHeight = 3f;
    //public Rigidbody playerRb;

    public float speed = 12f;
    public float gravity = -9.8f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Animator blasterAnim;


    Vector3 velocity;
    public Vector3 currentAngle;

    bool isGrounded;
    float blastTime;
    private void Start()
    {
        // playerRb = GetComponent<Rigidbody>();
        blastTime = Time.deltaTime;
    }


    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }
        if(Input.GetKeyDown(KeyCode.B) && blastTime > 0.25)
        {
            blasterAnim.SetBool("Blast", true);
            blastTime = 0;
        }
        if (blastTime > 0.5)
        {
            blasterAnim.SetBool("Blast", false);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        blastTime += Time.deltaTime;

    }

  
    
      
}



