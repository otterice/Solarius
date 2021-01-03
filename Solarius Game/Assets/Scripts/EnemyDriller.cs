using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Coffee.UIEffects
{
    public class EnemyDriller : MonoBehaviour
    {
        public float speed;
        private Waypoints Wpoints;
        private Animator anim;
        private bool finishedAnimation;
        private string planetName;
        private int waypointIndex;
        private float damage;
        bool stop = true;

        GameObject planet;
        planetHealth pHP;

        void Start()
        {
            anim = GetComponent<Animator>();
            finishedAnimation = false;

            int RNG = Random.Range(1, 5);

            //From the RNG, set the waypoints and the name of the planet
            if (RNG == 1)
            {
                Wpoints = GameObject.FindGameObjectWithTag("WayPointPurple").GetComponent<Waypoints>();
                planetName = "purplePlanet";
            }
            else if (RNG == 2)
            {
                Wpoints = GameObject.FindGameObjectWithTag("WayPointRed").GetComponent<Waypoints>();
                planetName = "redPlanet";
            }
            else if (RNG == 3)
            {
                Wpoints = GameObject.FindGameObjectWithTag("WayPointEarth").GetComponent<Waypoints>();
                planetName = "earth";
            }
            else
            {
                Wpoints = GameObject.FindGameObjectWithTag("WayPointOrange").GetComponent<Waypoints>();
                planetName = "orangePlanet";
            }

            planet = GameObject.Find(planetName);
            pHP = planet.GetComponent<planetHealth>();
        }

        private IEnumerator waitForAnimation()
        {
            anim.SetBool("isGettingDrillOut", true);
            //This doesnt get the 'exact' length of the animation
            //idk how to do it haha, search it up later...
            yield return new WaitForSeconds(1.5f);
            anim.SetBool("isGettingDrillOut", false);
            finishedAnimation = true;
        }

        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
            {
                if (stop)
                {
                    int random = Random.Range(1, 10);

                    for (int i = 0; i < random; i++)
                    {
                        waypointIndex++;

                    }
                    stop = false;
                }

                DamageDealer();
                if (finishedAnimation == false)
                {
                    anim.SetBool("isFlying", false);
                    StartCoroutine(waitForAnimation());
                }

                if (pHP.getHealth() <= 0)
                {
                    Destroy(gameObject);
                }

            }
        }

        //Deals damage to the planet
        void DamageDealer()
        {
            damage = 0.004f;
            pHP.TakeDamage(damage);
        }

    }

}