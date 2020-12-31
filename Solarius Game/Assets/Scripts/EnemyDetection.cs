using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{

    public GameObject MissilePrefab;
    private GameObject Right;
    //Enemy bullet mechanics
    [SerializeField] float shotCounter, minTimeBetweenShots, maxTimeBetweenShots;

    // Start is called before the first frame update
    void Start()
    {
        Right = GameObject.Find("Right");

    }

    // Update is called once per frame
    void Update()
    {
        
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

                shotCounter = 3f;
            
            }

        }

    }


}
