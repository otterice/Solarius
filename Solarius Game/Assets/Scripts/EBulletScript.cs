using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletScript : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D EBBod;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EBBod.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D hitCollision)
    {
        //Conditional still WIP to work with other planets
        // w/o yandere dev-esque code lolz 
        if (hitCollision.gameObject.name == "Radius")
        {
            Object.Destroy(gameObject);
            Debug.Log("hit planet");
        }
    }
}
