using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects
{


    public class PlanetHealthBar : MonoBehaviour
    {
        // Start is called before the first frame update
        public Slider planetHealth;
        public GameObject planet;
        public planetHealth pHealth;

        private string name;

        void Start()
        {
            name = planet.name;
            pHealth = GameObject.Find(name).GetComponent<planetHealth>();
            planetHealth = GetComponent<Slider>();
            planetHealth.maxValue = pHealth.health;
            planetHealth.value = pHealth.health;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetHealth(float hp)
        {
            planetHealth.value = hp;
        }
    }
}