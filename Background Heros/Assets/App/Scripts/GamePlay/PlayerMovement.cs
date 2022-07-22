using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Parameters")]

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;
    private bool isOnGround = true;
    private bool isDead = false;

    [Header("Links")]
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Animator playerAnimator;

    
    public void SetIsDead(bool newDead)
    {
        isDead = newDead;
        if (isDead == true)
            playerRb.bodyType = RigidbodyType2D.Static;
    }

    public bool GetIsDead()
    {
        return isDead;
    }

    private void movement()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("Vertical", Mathf.Abs(inputHorizontal));
        if (playerRb.bodyType == RigidbodyType2D.Dynamic)
        { 
        playerRb.velocity = new Vector2(inputHorizontal * movementSpeed * Time.fixedDeltaTime, playerRb.velocity.y);
        }


        if (inputHorizontal != 0 && !isDead)
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
        playerAnimator.SetBool("IsGround", isOnGround);
        playerAnimator.SetBool("Death", isDead);
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

        if(collision.gameObject.CompareTag("MoveableObstacles"))
        {
            gameObject.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("MoveableObstacles"))
        {
            gameObject.transform.parent = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Death"))
        {
            isDead = true;
            playerRb.bodyType = RigidbodyType2D.Static;
            Debug.Log("Dead!!!");
        }
    }







}
