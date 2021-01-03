using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Coffee.UIEffects
{
    public class planetHealth : MonoBehaviour
    {
        Powerups powerups;
        GameObject player;

        private string planetName;

        [SerializeField] float health = 100f;
        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("Player");
            powerups = player.GetComponent<Powerups>();
            planetName = gameObject.name;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("g"))
            {
                health -= 50;
            }
            planetDestroyed();
        }

        public float getHealth()
        {
            return health;
        }

        void planetDestroyed()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
        }

        private void OnDestroy()
        {
            powerups.setPlanetisDestroyed(planetName);
        }
    }

}