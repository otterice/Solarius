using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public float posX1;
    public float posX2;
    public float posY1;
    public float posY2;
    public float spawnTime = 8f;

    void Start()
    {
        InvokeRepeating("Spawner", 3, spawnTime);
    }

    void Spawner()
    {
            float posX = Random.Range(posX1, posX2); 
            float posY = Random.Range(posY1, posY2);
            Instantiate(enemy, new Vector2(posX, posY), Quaternion.identity);
    }
}
