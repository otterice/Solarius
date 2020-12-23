using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBulletScript : MonoBehaviour
{


    public float speed = 20f;
    public Rigidbody2D PBBod;
    // Start is called before the first frame update
    void Start()
    {
       
    }



    public void rotateRB(Rigidbody rb, Vector3 origin, Vector3 axis, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        rb.MovePosition(q * (rb.transform.position - origin) + origin);
        rb.MoveRotation(rb.transform.rotation * q);
    }


    private void OnTriggerStay2D(Collider2D hitCollision)
    {

        if(hitCollision.gameObject.name == "Enemy")
        {
            Debug.Log("Hit " + hitCollision.gameObject.name);
            Object.Destroy(gameObject);
        }
    }


}
