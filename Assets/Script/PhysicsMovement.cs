using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    Rigidbody rb;
    public float force_mult = 20f;
    public float maxSpeed = 100f; 

    bool moveForward;
    bool moveBackward;
    bool moveLeft;
    bool moveRight;
    bool moveUp;
    bool moveDown; 

    //HW IS TO CREATE AN ALIEN OBSTACLE COURSE

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controls();
        movePlayer();
        //limits speed
        if (rb.velocity.magnitude > maxSpeed){
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		}
    }

    void movePlayer(){
        if (moveForward){
            rb.AddForce(transform.forward * force_mult);
        }
        if (moveLeft){
            rb.AddForce(-transform.right * force_mult);
        }
        if (moveBackward){
            rb.AddForce(-transform.forward * force_mult);
        }
        if (moveRight){
            rb.AddForce(transform.right * force_mult);
        }
        if (moveUp){
            rb.AddForce(transform.up * force_mult);
        }
        if (moveDown){
            rb.AddForce(-transform.up * force_mult);
        }
    }

    void controls(){
        if (Input.GetKey(KeyCode.W)){
            moveForward = true;
        } else {
            moveForward = false;
        }
        if (Input.GetKey(KeyCode.A)){
            moveLeft = true;
        } else {
            moveLeft = false;
        }
        if (Input.GetKey(KeyCode.S)){
            moveBackward = true;
        } else {
            moveBackward = false;
        }
        if (Input.GetKey(KeyCode.D)){
            moveRight = true;
        } else {
            moveRight = false;
        }
        if (Input.GetKey(KeyCode.E)){
            moveUp = true;
        } else {
            moveUp = false;
        }
        if (Input.GetKey(KeyCode.Q)){
            moveDown = true;
        } else {
            moveDown = false;
        }
        if (Input.GetKey(KeyCode.J)){
            rb.velocity *= 0.95f; 
        }
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag != "Opp"){
            rb.useGravity = true;
            GetComponent<ParticleSystem>().Play();
        } else {
            Destroy(col.gameObject);
        }
    }
}
