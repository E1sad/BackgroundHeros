using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float randomSecondMin;
    [SerializeField] private float randomSecondMax;
    [SerializeField] private float TimeForDestroy;
    private float TimerForDestroy;
    float TimerForSpawn;
    GameObject forDestroy;

    [Header("Links")]
    [SerializeField] private GameObject circleObstacle;

    void SpawnCircle()
    {
        TimerForSpawn -= Time.deltaTime;
        if (TimerForSpawn <= 0f)
        {
            Instantiate(circleObstacle, transform.position, Quaternion.identity);
            TimerForSpawn = Random.Range(randomSecondMin, randomSecondMax);
        }
    }

    void DestroyCircle()
    {
        forDestroy = GameObject.FindGameObjectWithTag("ObstacleForSpawner");
        TimerForDestroy -= Time.deltaTime;
        if(forDestroy != null && TimerForDestroy <= 0)
        {
            Destroy(forDestroy);
            TimerForDestroy = TimeForDestroy;
        }
    }

    private void FixedUpdate()
    {
        SpawnCircle();
        DestroyCircle();
    }

}
