using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    planetHealth pH;
    playerStates pState;
    [SerializeField] GameObject[] planets;
    public bool redPlanetState;
    public bool earthState;
    public bool purplePlanetState;
    public bool awesome; 

    // Start is called before the first frame update
    void Start()
    {
       

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        //Reset each state to false to prepare for next planet jump
        redPlanetState = false;
        earthState = false;
        purplePlanetState = false;

        if(collision.gameObject.name == "purplePlanet")
        {
            purplePlanetState = true;
        }
        else if(collision.gameObject.name == "redPlanet")
        {
            redPlanetState = true;
        }
        else if(collision.gameObject.name == "earth")
        {
            earthState = true;
        }

    }

    public void setPlanetisDestroyed(string planetName) {
        if (planetName == "purplePlanet") {
            purplePlanetState = false;
        }
        else if (planetName == "redPlanet") {
            redPlanetState = false;
        }
        else if (planetName == "earth") {
            earthState = false;
        }
    }
}
