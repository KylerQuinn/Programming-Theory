using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Surface : MonoBehaviour
{
    protected GameObject player;

    protected GameManager gameManager;

    protected float positionLag;
    protected float moveDownSpeed;

    protected Collider surfaceCollider;
    protected Rigidbody surfaceRb;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        moveDownSpeed = gameManager.moveDownSpeed;

        player = GameObject.Find("Player");
        surfaceCollider = GetComponent<Collider>();
        surfaceRb = GetComponent<Rigidbody>();

        positionLag = PositionLag();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.isGameActive)
        {
            ChangeIsTrigger();
            ChangeUseGravity();
            MoveDown();
        }
    }

    protected virtual void ChangeUseGravity()
    {

    }

    protected virtual void ChangeIsTrigger()
    {
        if (player != null && player.transform.position.y > transform.position.y + positionLag)
        {
            // If player's collider under the surface
            surfaceCollider.isTrigger = false;
        }
        else if (player != null && player.transform.position.y < transform.position.y - positionLag)
        {
            // If player's collider above the surface
            surfaceCollider.isTrigger = true;
        }
    }

    private void MoveDown()
    {
        surfaceRb.MovePosition(transform.position + Vector3.down * Time.deltaTime * moveDownSpeed);
        //surfaceRb.velocity = Vector3.down * moveDownSpeed;
    }

    private float PositionLag()
    {
        // Distance from the center of player to it's tom or bottom
        
        if (player != null)
        {
            Collider playerCollider = player.GetComponent<Collider>();
            return playerCollider.bounds.size.y / 2;
        }

        return 0;
    }
}
