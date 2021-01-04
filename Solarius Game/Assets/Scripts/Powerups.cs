using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UIEffects
{
    public class Powerups : MonoBehaviour
    {
        public bool redPlanetState;
        public bool earthState;
        public bool purplePlanetState;
        public bool orangePlanetState;

        public bool redPlanetisDestroyed;
        public bool earthisDestroyed;
        public bool purplePlanetisDestroyed;
        public bool orangePlanetisDestroyed;
        public UIShiny effects;

        // Start is called before the first frame update
       
        private void resetStates()
        {
            redPlanetState = false;
            earthState = false;
            purplePlanetState = false;
            orangePlanetState = false;

            //redPlanetisDestroyed = false;
            //earthisDestroyed = false;
            //purplePlanetisDestroyed = false;
            //orangePlanetisDestroyed = false;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Reset each state to false to prepare for next planet jump

            if (collision.gameObject.name == "purplePlanet")
            {
                resetStates();
                purplePlanetState = true;
            }
            else if (collision.gameObject.name == "redPlanet")
            {
                resetStates();
                redPlanetState = true;
            }
            else if (collision.gameObject.name == "earth")
            {
                resetStates();
                earthState = true;
                SoundScript.PlaySound("player_shield");
            }
            else if (collision.gameObject.name == "orangePlanet")
            {
                resetStates();
                orangePlanetState = true;
            }
            else
            {
                return;
            }

        }

        public void setPlanetisDestroyed(string planetName)
        {   
            if (planetName == "purplePlanet")
            {
                purplePlanetState = false;
                purplePlanetisDestroyed = true;
            }
            else if (planetName == "redPlanet")
            {
                redPlanetState = false;
                redPlanetisDestroyed = true;
            }
            else if (planetName == "earth")
            {
                earthState = false;
                earthisDestroyed = true;
            }
            else if (planetName == "orangePlanet")
            {
                orangePlanetState = false;
                orangePlanetisDestroyed = true;
            }
        }
    }

}