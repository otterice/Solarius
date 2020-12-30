using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    

    [SerializeField] public int enemyHealth = 150;
    private GameObject hurtbox;

    public BoxCollider2D hboxCollider;
    // Start is called before the first frame update
    void Start()
    {
        hurtbox = GameObject.Find("Hurtbox");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if(!damageDealer)
        {
            return;
        } 
        else if (collision.gameObject.tag == "Hurtbox")
        {
            
            processHit(damageDealer);
        }
       

    }

    private void processHit(DamageDealer d)
    {
        //Gets how much damage the collision is doing
        enemyHealth -= d.getDamage();
        d.Hit();
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}