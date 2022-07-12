using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Parameters")]

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;

    [Header("Links")]
    [SerializeField] private Rigidbody2D playerRb;
    


    private void movement()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");

        playerRb.velocity = (transform.right * movementSpeed * inputHorizontal + transform.up*playerRb.velocity.y) * Time.fixedDeltaTime;
    }

    private void Update()
    {
        movement();
    }




}
