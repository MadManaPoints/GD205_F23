// These are called Directives

using System.Collections;
using System.Collections.Generic;

// Let's us know we're using Unity, knows where it is getting references from 
using UnityEngine;

// It can be accessed through other scripts 
// float means floating point number
public class BasicMovement : MonoBehaviour
{
    Vector3 movePlayer;
    Vector3 levelTwo;
    Vector3 levelThree;
    // Start is called before the first frame update
    void Start()
    {
       movePlayer = new Vector3(0f, 0f, 1f);
       levelTwo = new Vector3(7f, 1f, 35f);
       levelThree = new Vector3(0f, 1f, 70f);
    }

    // Update is called once per frame
    void Update(){
        controls();
        win();
    }

    void controls(){
        //Input is a class; GetKeyDown is a method 
        if (Input.GetKeyDown(KeyCode.W)){
            //print("W was pressed");
            //class is a category of a thing
            //object is a specific example of that thing
            transform.position += movePlayer;
        }
       
        if (Input.GetKeyDown(KeyCode.A)){
            transform.position += Vector3.left;
        }

        if (Input.GetKeyDown(KeyCode.S)){
            transform.position += Vector3.back;
        }

        if (Input.GetKeyDown(KeyCode.D)){
            transform.position += Vector3.right;
        }

        if (Input.GetKeyDown(KeyCode.Q)){
            transform.position += Vector3.up;
        }

        if (Input.GetKeyDown(KeyCode.E)){
            transform.position += Vector3.down;
        }

    }

    void win(){
        if (transform.position.x == 7 && transform.position.z == 7){
            print("YOU WIN!");
            transform.position += Vector3.up * 0.05f;
            if (transform.position.y > 20){
                transform.position = levelTwo;
            }
        }

        if (transform.position.x == 0 && transform.position.z == 42){
            print("YOU WIN!");
            transform.position += Vector3.up * 0.05f;
            if (transform.position.y > 20 && transform.position.z > 20){
                transform.position = levelThree;
            }
        }
    }

}

