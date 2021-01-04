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
        private string planetBarName;
        [SerializeField] public float health = 100f;
        public PlanetHealthBar bar;
        public GameObject planetBar;

        // Start is called before the first frame update
        void Start()
        {
            planetBarName = planetBar.name;
            bar = GameObject.Find(planetBarName).GetComponent<PlanetHealthBar>();
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

            bar.SetHealth(health);
        }

        private void OnDestroy()
        {
            powerups.setPlanetisDestroyed(planetName);
        }
    }

}