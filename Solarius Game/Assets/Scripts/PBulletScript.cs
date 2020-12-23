using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBulletScript : MonoBehaviour
{


    public float speed = 20f;
    public Rigidbody2D PBBod;
    //Calls every fixed framed
    void FixedUpdate()
    {
        //PBBod.AddForce(transform.right * speed);
        PBBod.velocity = transform.right * speed;
    }
 

  

    //private void OnTriggerStay2D(Collider2D hitCollision)
    //{

    //    if(hitCollision.gameObject.name == "Enemy")
    //    {
    //        Debug.Log("Hit " + hitCollision.gameObject.name);
    //        Object.Destroy(gameObject);
    //    }
    //}


}
