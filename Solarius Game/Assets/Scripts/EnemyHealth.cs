using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int enemyHealth = 150;
    [SerializeField] float time = 0.05f;
    [SerializeField] int scoreValue = 50;
    private Renderer sr;
    private IEnumerator coroutine;


    private void Start() {
        sr = GetComponentInParent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        } 
        else if (collision.gameObject.tag == "playerBullet")
        {
            Debug.Log(collision.gameObject.tag);
            processHit(damageDealer);
        }
    }

    private void processHit(DamageDealer d)
    {
        //Gets how much damage the collision is doing
        enemyHealth -= d.getDamage();
        SoundScript.PlaySound("enemy_hurt");
        d.Hit();
        if (enemyHealth <= 0)
        {
            Destroy(transform.parent.gameObject);
            SoundScript.PlaySound("enemy_explode");
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
        }
        StartCoroutine(flash());
    }

    //when enemy is hit, flash the sprite
    private IEnumerator flash() {
        for (int i = 0; i < 2; i++) {
            sr.enabled = false;
            yield return new WaitForSeconds(time);
            sr.enabled = true;
            yield return new WaitForSeconds(time);
        }
    }
}