using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CharacterStuff : MonoBehaviour
{
    CharacterController controller;
    Animator anim;
    public float speed = 3.0f;
    private float running = 0.0f;
    private float startSpeed;
    private float runSpeed = 4.0f; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        startSpeed = speed; 
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //Debug.Log(move);
        anim.SetFloat("Walk Forward", move.z);
        anim.SetFloat("Walk Backward", move.z);
        anim.SetFloat("Walk Left", move.x);
        anim.SetFloat("Walk Right", move.x); 
        anim.SetFloat("Run Forward", running);
        anim.SetFloat("Run Backward", running);
        anim.SetFloat("Run Left", running);
        anim.SetFloat("Run Right", running);
        
        if(Input.GetKeyDown(KeyCode.F)){
            anim.SetBool("Dance", true);
        }
        
        if(Input.GetKeyUp(KeyCode.F)){
        anim.SetBool("Dance", false);
        }

        
        if (Input.GetKeyDown(KeyCode.Space)){
            anim.SetTrigger("Jump Trig");
        }

        controller.Move(move * Time.deltaTime * speed);


        if(move.z > 0.5f && Input.GetKey(KeyCode.LeftShift)){
            running = 1.0f;
            speed = runSpeed;  
        } else if(move.z < -0.5f && Input.GetKey(KeyCode.LeftShift)){
            running = -1.0f;
            speed = runSpeed;  
        } else if(move.x < 0.5f && Input.GetKey(KeyCode.LeftShift)){
            running = -1.0f; 
            speed = runSpeed;
        } else if(move.x > 0.05f && Input.GetKey(KeyCode.LeftShift)){
            running = 1.0f;
            speed = runSpeed;
        } else {
            running = 0f;
            speed = startSpeed;
        }
    }
}
