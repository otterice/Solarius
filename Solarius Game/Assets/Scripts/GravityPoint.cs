using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPoint : MonoBehaviour
{
    public float gravityScale, planetRadius, gravityMinRange, gravityMaxRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerStay2D(Collider2D collision) {
        float gravitionalPower = gravityScale;
        float dist = Vector2.Distance(collision.transform.position, transform.position);

        if (dist > (planetRadius + gravityMinRange)) {
            float min = planetRadius + gravityMinRange;
            gravitionalPower = (((min + gravityMinRange) - dist) / gravityMaxRange) * gravitionalPower;
        }
        
        Vector3 dir = (transform.position - collision.transform.position) * gravitionalPower;
        collision.GetComponent<Rigidbody2D>().AddForce(dir);

        if (collision.CompareTag("Player")) {
            collision.transform.up = Vector3.MoveTowards(collision.transform.up, -dir, gravityScale * Time.deltaTime + 90);
        }
    }
}
