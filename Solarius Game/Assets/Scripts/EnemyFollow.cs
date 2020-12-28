using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;
    private Rigidbody2D body;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        body.AddForce(Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime));
    }
}
