using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public Transform planet;
    private float forceAmountForRotation = 10;
    private Vector3 directionOfPlanetFromBox;
    private bool allowForce;
    private Vector2 force;
    private float gravity = -2.0f;
    Rigidbody2D boxBod;


    private void Awake()
    {
        boxBod = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        directionOfPlanetFromBox = Vector3.zero;
    }

    void Update()
    {

        allowForce = false;

        if (Input.GetKey(KeyCode.Space))
            allowForce = true;

        directionOfPlanetFromBox = transform.position - planet.position;
        transform.right = Vector3.Cross(directionOfPlanetFromBox, Vector3.forward);

        
    }

    void FixedUpdate()

    {
        force = transform.right * forceAmountForRotation;
        boxBod.AddForce(transform.up * gravity);
        if (allowForce)
        boxBod.AddForce(force);
    }
}
