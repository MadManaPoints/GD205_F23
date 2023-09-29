using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    Rigidbody rb;
    public float force_mult = 5f;

    //HW IS TO CREATE AN ALIEN OBSTACLE COURSE


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        controls();
    }

    void controls(){
        if (Input.GetKey(KeyCode.W)){
            rb.AddForce(transform.forward * force_mult);
        }
        if (Input.GetKey(KeyCode.A)){
            rb.AddForce(-transform.right * force_mult);
        }
        if (Input.GetKey(KeyCode.S)){
            rb.AddForce(-transform.forward * force_mult);
        }
        if (Input.GetKey(KeyCode.D)){
            rb.AddForce(transform.right * force_mult);
        }
        if (Input.GetKey(KeyCode.J)){
            rb.velocity *= 0.95f; 
        }
    }
}
