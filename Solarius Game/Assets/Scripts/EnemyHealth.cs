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
        hboxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if(!damageDealer)
        {
            return;
        } 
        else if (collision.gameObject.tag == "Bullet")
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
            Destroy(transform.parent.gameObject);
        }
    }

}