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
            posX = Random.Range(-0.45f, 2.13f);
            posY = Random.Range(-2.15f, 1.95f);
            Instantiate(enemy, new Vector2(posX, posY), Quaternion.identity);
            counter++;
        }
    }
}
