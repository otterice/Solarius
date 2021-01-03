using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public Health hp;
    public HealthBar healthBar;

    private void Start() {
        hp = FindObjectOfType<Health>();
        healthBar = FindObjectOfType<HealthBar>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name.Equals("Player")) {
            hp.health = 0;
            healthBar.SetHealth(hp.health);
            hp.doOnDeath();
        }
        else {
            Destroy(collision.gameObject);
        }
    }
}
