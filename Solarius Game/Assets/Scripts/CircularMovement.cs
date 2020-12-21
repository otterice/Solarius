using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;  // ...or whatever.

    void Update() {
        

        if (Input.GetKey("a")) {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey("d")) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
