using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    Vector3 velocity;
    public Vector3 currentAngle;

    public float hitpoints = 3;
    public TextMeshProUGUI gameOverScreen;

    bool isGrounded;
    private void Start()
    {
       // playerRb = GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
        // gameOverScreen = gameObject.GetComponent<TextMeshProUGUI>();
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
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (hitpoints <= 0)
        {
            Debug.Log("here");
            gameOverScreen.gameObject.SetActive(true);
            controller.enabled = false;
        }

    }

  
    
      
}



