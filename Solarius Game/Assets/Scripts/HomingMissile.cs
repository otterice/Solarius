using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float rotateSpeed = 200f;

    public GameObject explosionVFX;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() //use fixedUpdate to mess around with physics
    {
        Vector2 direction = (Vector2) target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed; 
    }
}
