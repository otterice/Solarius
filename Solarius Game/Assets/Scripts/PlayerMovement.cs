using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jump = 3f;

    private bool isGrounded;
    private float horizontal;

    private void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump")) {
            body.AddForce(transform.up * jump, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate() {
        body.AddForce(transform.right * horizontal * moveSpeed); //Mathf.clamp to not overshoot the character
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Planet")) {
            body.drag = 1f;

            float distance = Mathf.Abs(collision.GetComponent<GravityPoint>().planetRadius - Vector2.Distance(transform.position, collision.transform.position));
            if (distance < 1f) {
                isGrounded = distance < 0.1f; 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        body.drag = 0.2f;
    }
}