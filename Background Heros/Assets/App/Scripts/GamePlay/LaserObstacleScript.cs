using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObstacleScript : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float distance;
    private PlayerMovement player;

    [Header("Links")]
    [SerializeField] private LineRenderer line;
    [SerializeField] private GameObject laserSource;

    void LaserHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance);
        line.SetPosition(0, transform.position);
        
        
        if(hit.collider != null)
        {
            line.SetPosition(1, hit.point);
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                player.SetIsDead(true);
            }
        }
        else
        {
            line.SetPosition(1, new Vector2(transform.position.x+distance, transform.position.y));
        }
    }

    private void FixedUpdate()
    {
        LaserHit();
    }
}
