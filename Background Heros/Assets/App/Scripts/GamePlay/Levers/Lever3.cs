using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever3 : MonoBehaviour
{
    private int IsTurn = -1;
    private bool collected = false;
    

    [SerializeField] private SpriteRenderer Renderer;
    [SerializeField] private Sprite image1;
    [SerializeField] private Sprite imageMinus1;

    public int GetIsTurn()
    {
        return IsTurn;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (!collected && Input.GetKeyUp(KeyCode.E) && collision.transform.gameObject.CompareTag("Player"))
        {
            IsTurn *= -1;
            collected = true;
            Debug.Log(collected);
        }

    }

    private void Update()
    {
        if (collected == true)
        {
            collected = false;
            Debug.Log(collected);
        }
        if (IsTurn == 1)
            Renderer.sprite = image1;
        if (IsTurn == -1)
            Renderer.sprite = imageMinus1;
    }

    private void FixedUpdate()
    {

    }

}
