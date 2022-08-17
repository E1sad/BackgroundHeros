using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObstacleScriptLever : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float distance;
    

    [Header("Links")]
    [SerializeField] private LineRenderer line;
    [SerializeField] private GameObject laserSource;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private LayerMask playerLayer;

    void LaserHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(laserSource.transform.position, -Vector2.up, distance, playerLayer); ;
        line.SetPosition(0, laserSource.transform.position);
        
        
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
            line.SetPosition(1, new Vector2(laserSource.transform.position.x, laserSource.transform.position.y - distance));
        }
    }

    private void FixedUpdate()
    {
        LaserHit();
    }
}
