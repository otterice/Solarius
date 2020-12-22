using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public Transform planet;
    private float forceAmountForRotation = 10;
    private Vector3 directionOfPlanetFromBird;
    private bool allowForce;
    private Vector2 force;
    Rigidbody2D boxBod;


    private void Awake()
    {
        boxBod = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        directionOfPlanetFromBird = Vector3.zero;
    }

    void Update()
    {

        allowForce = false;

        if (Input.GetKey(KeyCode.Space))
            allowForce = true;

        directionOfPlanetFromBird = transform.position - planet.position;
        transform.right = Vector3.Cross(directionOfPlanetFromBird, Vector3.forward);
    }

    void FixedUpdate()

    {
        force = transform.right * forceAmountForRotation;
        if (allowForce)
            boxBod.AddForce(force);
    }
}
