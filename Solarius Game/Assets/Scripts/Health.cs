using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //gets the damage of the collision that entered the hurtbox
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) {
            return;
        }
        processHit(damageDealer);
    }

    private void processHit(DamageDealer d) {
        //Gets how much damage the collision is doing
        health -= d.getDamage();
        d.Hit();
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}
