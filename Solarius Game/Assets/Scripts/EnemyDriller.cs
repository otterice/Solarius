using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDriller : MonoBehaviour
{
    public float speed;
    private Waypoints Wpoints;
    private Animator anim;
    private bool finishedAnimation;
    private string planetName;
    private int waypointIndex;
    private float damage;

    GameObject planet;
    planetHealth pHP;

    void Start()
    {
        anim = GetComponent<Animator>();
        finishedAnimation = false;

        int RNG = Random.Range(1, 4);

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
        else
        {
            Wpoints = GameObject.FindGameObjectWithTag("WayPointEarth").GetComponent<Waypoints>();
            planetName = "earth";
        }

        planet = GameObject.Find(planetName);
        pHP = planet.GetComponent<planetHealth>();
    }

    private IEnumerator waitForAnimation() {
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
            if (waypointIndex < Wpoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                if (finishedAnimation == false) {
                    anim.SetBool("isFlying", false);
                    StartCoroutine(waitForAnimation());
                }
                DamageDealer();
                //Make the enemy do something after the planet is gone
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
