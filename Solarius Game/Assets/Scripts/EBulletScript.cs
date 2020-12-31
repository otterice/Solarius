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


}
