using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public Transform player;
    float direction;
    public float maxSpeed = 25;
    public float forceMult = 5f; 
    private bool run = false;
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
         
        if (run){
            var direction = (player.transform.position - this.transform.position);
            rb.AddForce(Vector3.Normalize(-direction) * forceMult);
        }
    }

    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Player"){
            run = true;
        }
    }

    void OnTriggerExit(Collider col){
        if (col.gameObject.tag == "Player"){
            run = false;
        }
    }
}
