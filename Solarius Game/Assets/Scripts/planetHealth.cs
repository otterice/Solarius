using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Coffee.UIEffects
{
    public class planetHealth : MonoBehaviour
    {
        [SerializeField] GameObject prefabVFX;
        Powerups powerups;
        Health hp;
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
            hp = player.GetComponent<Health>();
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


        //public void doOnDeath()
        //{
        //    FindObjectOfType<Level>().LoadGameOver();
        //    //SoundScript.PlaySound("player_explode");
        //    Destroy(gameObject);
            
        //}

        public void TakeDamage(float amount)
        {
            health -= amount;

            bar.SetHealth(health);
        }

        private void OnDestroy()
        {
            powerups.setPlanetisDestroyed(planetName);
            SoundScript.PlaySound("planet_explode");
            GameObject death = Instantiate(prefabVFX, transform.position, transform.rotation);

            if (powerups.redPlanetisDestroyed && powerups.purplePlanetisDestroyed
                && powerups.earthisDestroyed && powerups.orangePlanetisDestroyed)
            {
                //call player death as well
                hp.deathVisualizer();
                FindObjectOfType<Level>().LoadGameOver();
            }

        }
    }

}