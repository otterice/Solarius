using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    private Transform target;
    private Rigidbody2D body;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
<<<<<<< Updated upstream
        body.AddForce(Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime));
=======
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
>>>>>>> Stashed changes
    }

}