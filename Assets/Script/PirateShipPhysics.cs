using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShipPhysics : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    public Transform player;
    float direction;
    public float maxSpeed = 40;
    public float forceMult = 10f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed){
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
         
        transform.LookAt(player);
        var direction = (player.transform.position - this.transform.position);
        rb.AddForce(Vector3.Normalize(direction) * forceMult);
    }
}
