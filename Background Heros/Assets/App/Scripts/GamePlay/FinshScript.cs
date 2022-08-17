using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinshScript : MonoBehaviour
{
    [SerializeField] GameObject FinishPanel;
    [SerializeField] PlayerMovement player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FinishPanel.SetActive(true);
            player.SetIsDead(true);
        }
    }
}
