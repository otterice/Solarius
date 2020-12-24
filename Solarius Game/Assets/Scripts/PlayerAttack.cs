using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    playerStates p; 

    public GameObject pBulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<playerStates>();
        p.lookingLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left")) {
            p.lookingLeft = true;
        }
        else if (Input.GetKeyDown("right")) { 
            p.lookingLeft = false;
        }
        if (Input.GetKeyDown("f")) {
            Shoot();
        }
    }


    void Shoot() {
        GameObject newBullet = Instantiate(pBulletPrefab, transform.position, transform.rotation);
        if (p.lookingLeft) {
            newBullet.transform.right = -1 * transform.right.normalized;
        }
        else {
            newBullet.transform.right = transform.right.normalized;
        }
    }
}

