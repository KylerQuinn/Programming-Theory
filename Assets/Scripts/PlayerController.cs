using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private const float jumpForce = 10;
    private const float moveForce = 10;

    private bool isOnGround = false;

    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
    }

    void FixedUpdate()
    {
        HorizontalMovement();
    }

    private void HorizontalMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(horizontalInput * moveForce * Vector3.right);
    }

    private void PlayerJump()
    {
        if (isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Can jump only from the ground
        
        if (!collision.collider.isTrigger)
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Can't jump from air
        
        if (!collision.collider.isTrigger)
        {
            isOnGround = false;
        }
    }
}
