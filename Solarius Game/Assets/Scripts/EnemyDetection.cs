using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public Transform firePoint;
    public GameObject ebulletPrefab;
    //Enemy bullet mechanics
    [SerializeField] float shotCounter, minTimeBetweenShots, maxTimeBetweenShots;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack() 
    {
        Instantiate(ebulletPrefab, firePoint.position, firePoint.rotation);
    }

    //Utilizes trigger trait of component 
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Call attack method each time collider is triggered by gameObject player
        if(collision.gameObject.name == "Player")
        {

        
            shotCounter -= Time.deltaTime;
            Debug.Log(shotCounter);
            if (shotCounter <= 0f)
            {
                for (int i = 0; i < 3; ++i)
                {
                    Attack();
                }

                shotCounter = 3f;
            
            }

        }

    }


}
