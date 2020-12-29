using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    playerStates p; 

    public GameObject pBulletPrefab;
    private GameObject leftFace;
    private GameObject rightFace;
    public SpriteRenderer sr; 
    // Start is called before the first frame update
    void Start()
    {
        //Gets player states
        p = GetComponent<playerStates>();
        leftFace = GameObject.Find("LeftFacing");
        rightFace = GameObject.Find("RightFacing");
        p.lookingLeft = true;
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
        }
    }


    void Shoot()
    {

        GameObject newBullet = Instantiate(pBulletPrefab, transform.position, transform.rotation);
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
}
