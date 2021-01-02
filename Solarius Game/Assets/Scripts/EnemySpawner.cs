using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public float posX;
    public float posY;
    public float spawnTime = 3f;
    [SerializeField] int counter = 0;

    void Start()
    {
        InvokeRepeating("Spawner", spawnTime, 1);
    }

    void Spawner()
    {
        if (counter >= 10)
        {
            CancelInvoke();
        }
        else
        {
            posX = Random.Range(-27.77f, -19.22f); 
            posY = Random.Range(0.12f, 8.0f);
            Instantiate(enemy, new Vector2(posX, posY), Quaternion.identity);
            counter++;
        }
    }
}
