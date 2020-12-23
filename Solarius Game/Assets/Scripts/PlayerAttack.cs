using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject pBulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f"))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        Instantiate(pBulletPrefab, firePoint.position, firePoint.rotation);
    }
}

