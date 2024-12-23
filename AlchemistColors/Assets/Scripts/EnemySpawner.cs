using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnerEnemy;
    [SerializeField] private Transform[] spawnPoint;
    public float startSpawnerInterval;
    private float  spawnerInterval;
    private int randEnemy;
    private int randPoint;

    void Start()
    {
        spawnerInterval = startSpawnerInterval;
    }

    void Update()
    {
        if (spawnerInterval <= 0)
        {
            randEnemy = Random.Range(0, spawnerEnemy.Length);
            randPoint = Random.Range(0, spawnPoint.Length);

            Instantiate(spawnerEnemy[randEnemy], spawnPoint[randPoint].position, Quaternion.identity);
            if (startSpawnerInterval > 1.5f) startSpawnerInterval -= 0.1f;
            spawnerInterval = startSpawnerInterval;
        }
        else 
        {
            spawnerInterval -= Time.deltaTime;
        }
    }
}
