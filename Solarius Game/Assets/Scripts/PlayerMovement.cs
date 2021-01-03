using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Coffee.UIEffects
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D body;

        [SerializeField] float moveSpeed = 5f;
        [SerializeField] float jump = 3f;
        [SerializeField] float speedMod = 5f;

        private bool isGrounded;
        private float horizontal;
        private float vertical;
        private Powerups powerups;
        private GameObject player;

        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
            player = GameObject.Find("Player");
            powerups = player.GetComponent<Powerups>();
        }

        private void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            if (Input.GetButtonDown("Jump"))
            {
                body.AddForce(transform.up * jump, ForceMode2D.Impulse);
                SoundScript.PlaySound("player_jump");
                Debug.Log("jump");
            }
        }

        private void FixedUpdate()
        {
            if (powerups.orangePlanetState == true)
            {
                body.AddForce(transform.right * horizontal * (moveSpeed + speedMod));
                return;
            }
            body.AddForce(transform.right * horizontal * moveSpeed); //Mathf.clamp to not overshoot the character
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Planet"))
            {
                body.drag = 1f;

                float distance = Mathf.Abs(collision.GetComponent<GravityPoint>().planetRadius - Vector2.Distance(transform.position, collision.transform.position));
                if (distance < 1f)
                {
                    isGrounded = distance < 0.1f;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            body.drag = 0.2f;
        }
    }
}