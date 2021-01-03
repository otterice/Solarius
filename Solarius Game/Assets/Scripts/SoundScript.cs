using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{

    public static AudioClip playerDeath, playerShootSingle, playerShootBig,
                            playerHurt, playerJump, playerShield,
                            playerShootTriple, enemyShoot, enemyDeath,
                            enemyHurt;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();

        //MUST USE RESOURCES FOLDER TO LOAD AUDIO SOURCES
        playerDeath = Resources.Load<AudioClip>("player_explode");
        playerShootSingle = Resources.Load<AudioClip>("player_shoot_single");
        playerShootTriple = Resources.Load<AudioClip>("player_shoot_triple");
        playerShootBig = Resources.Load<AudioClip>("Player_shoot_big");
        playerHurt = Resources.Load<AudioClip>("Player_hurt");
        playerJump = Resources.Load<AudioClip>("player_jump");
        playerShield = Resources.Load<AudioClip>("player_shield");


        enemyDeath = Resources.Load<AudioClip>("enemy_explode");
        enemyShoot = Resources.Load<AudioClip>("enemy_shoot");
        enemyHurt = Resources.Load<AudioClip>("enemy_hurt");
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
            case "player_shoot_triple":
                audioSrc.PlayOneShot(playerShootTriple);
                break;
            case "player_shoot_big" :
                audioSrc.PlayOneShot(playerShootBig);
                break;
            case "player_shoot_single":
                audioSrc.PlayOneShot(playerShootSingle);
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
            case "enemy_hurt":
                audioSrc.PlayOneShot(enemyHurt);
                break;

        }
    }
}
