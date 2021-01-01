using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{

    public static AudioClip playerDeath, playerShoot, playerHurt, 
                            playerJump, playerShield, enemyShoot, 
                            enemyDeath;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();

        playerDeath = Resources.Load<AudioClip>("player_explode");
        playerShoot = Resources.Load<AudioClip>("Player_shoot");
        playerHurt = Resources.Load<AudioClip>("Player_hurt");
        playerJump = Resources.Load<AudioClip>("player_jump");
        playerShield = Resources.Load<AudioClip>("player_shield");


        enemyDeath = Resources.Load<AudioClip>("enemy_explode");
        enemyShoot = Resources.Load<AudioClip>("enemy_shoot");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void PlaySound(string audioclip)
    {
        switch(audioclip)
        {
            case "player_explode":
                 audioSrc.PlayOneShot(playerDeath);
                    break;
            case "player_shoot" :
                audioSrc.PlayOneShot(playerShoot);
                break;
            case "player_hurt" :
                audioSrc.PlayOneShot(playerHurt);
                break;
            case "player_jump":
                audioSrc.PlayOneShot(playerJump);
                break;
            case "player_shield":
                audioSrc.PlayOneShot(playerShield);
                break;
            case "enemy_explode":
                audioSrc.PlayOneShot(enemyDeath);
                break;
            case "enemy_shoot":
                audioSrc.PlayOneShot(enemyShoot);
                break;

        }
    }
}
