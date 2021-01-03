using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Coffee.UIEffects
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] float time = 1f;

        private CircleCollider2D cC2D;
        private SpriteRenderer sr;
        private Powerups powerups;
        private GameObject player;

        private bool notDamaged;


        // Start is called before the first frame update
        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            cC2D = GetComponent<CircleCollider2D>();
            player = GameObject.Find("Player");
            powerups = player.GetComponent<Powerups>();
            sr.enabled = false;
            notDamaged = true;
        }

        IEnumerator WaitTime()
        {
            notDamaged = false;
            cC2D.enabled = false;
            sr.enabled = false;
            yield return new WaitForSeconds(time);
            cC2D.enabled = true;
            sr.enabled = true;
            notDamaged = true;
        }

        private void Update()
        {
            if (powerups.earthState && notDamaged)
            {
                cC2D.enabled = true;
                sr.enabled = true;
            }
            else
            {
                cC2D.enabled = false;
                sr.enabled = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (powerups.earthState && notDamaged)
            {
                DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
                if (!damageDealer)
                {
                    return;
                }
                damageDealer.Hit();
                StartCoroutine(WaitTime());
            }

        }
    }
}