using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public bool redPlanetState;
    public bool earthState;
    public bool purplePlanetState;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    private void resetStates() {
        redPlanetState = false;
        earthState = false;
        purplePlanetState = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Reset each state to false to prepare for next planet jump

        if(collision.gameObject.name == "purplePlanet")
        {
            resetStates();
            purplePlanetState = true;
        }
        else if(collision.gameObject.name == "redPlanet")
        {
            resetStates();
            redPlanetState = true;
        }
        else if(collision.gameObject.name == "earth")
        {
            resetStates();
            earthState = true;
        }
        else {
            return;
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
