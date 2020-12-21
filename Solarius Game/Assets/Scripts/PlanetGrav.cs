using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlanetGrav : MonoBehaviour
{
    public Transform box;
    private float gravitationalForce = 5;
    private Vector3 directionOfBoxFromPlanet;
    Rigidbody2D planetBod;

    private void Awake()
    {
        planetBod = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        directionOfBoxFromPlanet = Vector3.zero;
    }

    void FixedUpdate()
    {
        directionOfBoxFromPlanet = (transform.position - box.position).normalized;
        planetBod.AddForce(directionOfBoxFromPlanet * gravitationalForce);
    }
}
