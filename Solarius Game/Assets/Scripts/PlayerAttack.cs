using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    playerStates p; 

    public GameObject pBulletPrefab;
    public GameObject pBiggerBulletPrefab;

    private GameObject leftFace;
    private GameObject rightFace;
    private GameObject player;
    private Powerups powerups;

    public SpriteRenderer sr; 
    // Start is called before the first frame update
    void Start()
    {
        //Gets player states
        p = GetComponent<playerStates>();
        leftFace = GameObject.Find("LeftFacing");
        rightFace = GameObject.Find("RightFacing");
        p.lookingLeft = false;
        player = GameObject.Find("Player");
        powerups = player.GetComponent<Powerups>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left")) {
            p.lookingLeft = true;
            sr.flipX = true;
        }
        else if (Input.GetKeyDown("right")) { 
            p.lookingLeft = false;
            sr.flipX = false;
        }
        if (Input.GetKeyDown("f")) {
            Shoot();
            TriShot();
        }
    }


    //Big red funny bullet
    void Shoot()
    {
        GameObject newBullet;
        if (!powerups.redPlanetState) {
            newBullet = Instantiate(pBulletPrefab, transform.position, transform.rotation);
        }
        else {
            newBullet = Instantiate(pBiggerBulletPrefab, transform.position, transform.rotation);
        }

        if (p.lookingLeft)
        {
            //Finds the GameObject "RightFacing", under the parent of Player
            //Player has two gameObject children and gets the transform.position of them
            newBullet.transform.position = leftFace.transform.position;
            newBullet.transform.right = -1 * transform.right.normalized;
        }
        else
        {
            newBullet.transform.position = rightFace.transform.position;
            newBullet.transform.right = transform.right.normalized;
        }
        
    }

    //Hilarious triple shot
    void TriShot() {
        if (powerups.purplePlanetState) {
            GameObject newBullet2 = Instantiate(pBulletPrefab, transform.position, transform.rotation);
            GameObject newBullet3 = Instantiate(pBulletPrefab, transform.position, transform.rotation);


            if (p.lookingLeft) {

                newBullet2.transform.position = leftFace.transform.position;
                newBullet2.transform.right = -1 * transform.right.normalized;
                newBullet2.transform.rotation *= Quaternion.Euler(0, 0, 30);

                newBullet3.transform.position = leftFace.transform.position;
                newBullet3.transform.right = -1 * transform.right.normalized;
                newBullet3.transform.rotation *= Quaternion.Euler(0, 0, -30);
            }

            else {
                newBullet2.transform.position = rightFace.transform.position;
                newBullet2.transform.right = transform.right.normalized;
                newBullet2.transform.rotation *= Quaternion.Euler(0, 0, 30);

                newBullet3.transform.position = rightFace.transform.position;
                newBullet3.transform.right = transform.right.normalized;
                newBullet3.transform.rotation *= Quaternion.Euler(0, 0, -30);
            }
        }         
    }
}
