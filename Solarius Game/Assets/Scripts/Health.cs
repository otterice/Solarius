using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int health = 100;
    [SerializeField] float time = 0.05f;
    [SerializeField] GameObject prefabVFX;

    public HealthBar healthBar;

    private Renderer sr;
    private IEnumerator coroutine;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<Renderer>();
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
        healthBar.SetHealth(health);
        SoundScript.PlaySound("player_hurt");
        d.Hit();
        if (health <= 0) {
            FindObjectOfType<Level>().LoadGameOver();
            SoundScript.PlaySound("player_explode");
            Destroy(gameObject);
            GameObject death = Instantiate(prefabVFX, transform.position, transform.rotation);
            Destroy(death, 0.5f);
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
