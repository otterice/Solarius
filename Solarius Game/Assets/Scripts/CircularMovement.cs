using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;
    public Vector2 jumpHeight;

    void Update() {


        if (Input.GetKey("a")) {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey("d")) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

           
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if(Input.GetKey("s"))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
