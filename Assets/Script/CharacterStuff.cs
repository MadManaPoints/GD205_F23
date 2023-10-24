using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStuff : MonoBehaviour
{
    CharacterController controller;
    Animator anim;
    public float speed = 3.0f; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //Debug.Log(move);
        anim.SetFloat("Movement", move.z); 
        anim.SetFloat("Smoke", move.x);
        controller.Move(move * Time.deltaTime * speed);
    }
}
