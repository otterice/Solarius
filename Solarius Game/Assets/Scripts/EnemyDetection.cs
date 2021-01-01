using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public GameObject MissilePrefab;
    private GameObject Right;

    public Rigidbody2D self;

    public Transform playerTransform;

    public float rotateSpeed = 200f;

    //Enemy bullet mechanics
    [SerializeField] float shotCounter, minTimeBetweenShots, maxTimeBetweenShots;

    // Start is called before the first frame update
    void Start()
    {
        Right = GameObject.Find("Right");
        self = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Put this code in its own script DIRECT COPY FROM HOMING MISSILE
        //THIS IS HOW YOU REUSE CODE GUYS!!!!!! 
        Vector2 direction = (Vector2)playerTransform.position - self.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        self.angularVelocity = rotateAmount * rotateSpeed;


    }

    void Attack() 
    {
        GameObject missile = Instantiate(MissilePrefab, transform.position, transform.rotation);
       

    }

    //Utilizes trigger trait of component 
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Call attack method each time collider is triggered by gameObject player
        if(collision.gameObject.name == "Player")
        {       
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0f)
            {
                Attack();
                SoundScript.PlaySound("enemy_shoot");
                shotCounter = 3f;
            
            }

        }

    }


}
