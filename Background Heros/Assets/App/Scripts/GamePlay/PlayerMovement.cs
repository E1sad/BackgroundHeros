using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Parameters")]

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;
    private bool isOnGround = true;

    [Header("Links")]
    [SerializeField] private Rigidbody2D playerRb;
    


    private void movement()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector2(inputHorizontal * movementSpeed * Time.fixedDeltaTime, playerRb.velocity.y); 
        
        if(inputHorizontal != 0)
        {
            transform.localScale = new Vector3 (Mathf.Sign(inputHorizontal), 1, 1);
        }
    }

    private void jump()
    {
        isOnGround = false;
        playerRb.AddForce(playerRb.transform.up * jumpHeight,ForceMode2D.Impulse);
    }
    
    private void FixedUpdate()
    {
        movement();
    }

    private void Update()
    {
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isOnGround = true;
        }
    }





}
