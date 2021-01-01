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
        redPlanetState = earthState = purplePlanetState = true;

    }

    public void setPlanetisDestroyed(string planetName) {
        if (planetName == "purplePlanet") {
            purplePlanetState = false;
        }
    }



}
