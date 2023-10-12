using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    Rigidbody rb;
    public float forceMult = 0f;
    public float hForceMult = 0f;
    public float vForceMult = 0f;
    public float maxSpeed = 144f; 
    public float turnSpeed = 50f; 

    public float vInput;
    public float hInput;
    private bool forward;
    private bool backward;
    private bool left;
    private bool right;
    private bool up;
    private bool down;    
    private bool crash;
    private Vector3 grow = new Vector3(.5f, .5f, .5f);
    private float bigBoy = 4f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!crash){
            controls();
            movePlayer();
        }
        
        //limits speed
        if (rb.velocity.magnitude > maxSpeed){
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		}
    }

    void movePlayer(){

        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        if (forward || backward){
            rb.AddForce(transform.forward * forceMult * vInput);
        }
        
        if (left || right){
            if (forward || backward){
                rb.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * hInput);
            } else {
                rb.AddForce(transform.right * hForceMult * hInput);
            }
        }

        if (up){
            rb.AddForce(transform.up * vForceMult);
        }
        if (down){
            rb.AddForce(-transform.up * vForceMult);
        }

        if (Input.GetKey(KeyCode.J)){
            rb.velocity *= 0.95f; 
        }
    }

    void controls(){
        if (Input.GetKey(KeyCode.W)){
            forward = true; 
        } else {
            forward = false;
        }
        if (Input.GetKey(KeyCode.S)){
            backward = true;
        } else {
            backward = false;
        }
        if (Input.GetKey(KeyCode.A)){
            left = true;
        } else {
            left = false;
        }
        if (Input.GetKey(KeyCode.D)){
            right = true;
        } else {
            right = false;
        }
        if (Input.GetKey(KeyCode.Q)){
            down = true;
        } else {
            down = false;
        }
        if (Input.GetKey(KeyCode.E)){
            up = true;
        } else {
            up = false;
        }
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag != "Opp" && col.gameObject.tag != "Ship"){
            crash = true;
            rb.useGravity = true;
            GetComponent<ParticleSystem>().Play();
        } else if (col.gameObject.tag == "Opp"){
            Destroy(col.gameObject);
            transform.localScale += grow;
        } else if (col.gameObject.tag == "Ship" && transform.localScale.x > bigBoy){
            Destroy(col.gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
