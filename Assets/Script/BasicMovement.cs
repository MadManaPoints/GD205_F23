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
    Vector3 moveDown; 
    bool nextLevel = false;
    Vector3 levelTwo;
    public bool firstThreshold = false;
    public bool secondThreshold = false;
    Vector3 levelThree;
    Vector3 retry;
    public GameObject [] hazards;
    public GameObject [] keys;
    public GameObject [] goals;
    public GameObject [] walls;
    Vector3 aboveGoal;
    bool [] keyArray = new bool [2];
    public AudioClip death;
    public AudioClip rise;
    public AudioClip key;
    public AudioClip cheer;
    AudioSource player;
    void Start()
    {
       movePlayer = new Vector3(0f, 0f, 1f);
       moveDown = new Vector3(0f, 0f, -1f);
       retry = transform.position; 
       levelTwo = new Vector3(7f, 1f, 35f);
       levelThree = new Vector3(0f, 1f, 70f);
       aboveGoal = new Vector3(0f, 1f, 0f);
       //will get audio attached to this object 
       player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        if (transform.position.y == 1){
            controls();
        }
        collisions();
        win();
    }

    void controls(){
        //Input is a class; GetKeyDown is a method
        //class is a category of a thing
        //object is a specific example of that thing
        if (secondThreshold){
            if (transform.position.z < 77 && Input.GetKeyDown(KeyCode.W)){
                transform.position += movePlayer;
            } 
        } else if (firstThreshold){
            if (transform.position.z < 42 && Input.GetKeyDown(KeyCode.W)){
                transform.position += movePlayer;
            }
        } else if (transform.position.z < 7 && Input.GetKeyDown(KeyCode.W)){
                transform.position += movePlayer;
                }

        if (transform.position.x > 0){
            if (Input.GetKeyDown(KeyCode.A)){
                transform.position += Vector3.left;
            }
        }


        if (secondThreshold){
            if (transform.position.z > 70 && Input.GetKeyDown(KeyCode.S)){
                transform.position += moveDown;
            } 
        } else if (firstThreshold){
            if (transform.position.z > 35 && Input.GetKeyDown(KeyCode.S)){
                transform.position += moveDown;
            }
        } else if (transform.position.z > 0){
             if (Input.GetKeyDown(KeyCode.S)){
                transform.position += moveDown;
            }
        }

        if (transform.position.x < 7){
            if (Input.GetKeyDown(KeyCode.D)){
                transform.position += Vector3.right;
            }
        }
    }

    void collisions(){
        for (int i = 0; i < hazards.Length; i++){
            if (transform.position == hazards[i].transform.position){
                if (secondThreshold == true){
                    transform.position = levelThree;
                } else if (firstThreshold == true){
                    transform.position = levelTwo;
                } else {
                    transform.position = retry;
                }
                player.PlayOneShot(death, .75f);
            }
        }
        for (int i = 0; i < keys.Length; i++){
            if (transform.position == keys[i].transform.position){
                keys[i].transform.position += Vector3.down;
                player.PlayOneShot(key, .6f);
                for (int n = 0; n < keyArray.Length; n++){
                    keyArray[n] = true;
                    /*if (keyArray[0] == true){
                        print("GOT IT");
                    }*/
                }
            }
        }
    }

    void win(){
        for (int i = 0; i < goals.Length; i++){
            for (int n = 0; n < keyArray.Length; n++){
                if (keyArray[n] && transform.position == goals[i].transform.position + aboveGoal){
                    print("YOU WIN!");
                    keyArray[n] = false;
                    player.PlayOneShot(rise, .6f);
                    nextLevel = true;
                }
            }
        }
            
            if (nextLevel){
                if (!secondThreshold){
                    transform.position += Vector3.up * 0.05f;
                } else {
                    player.PlayOneShot(cheer, .3f);
                }    
            }

            if (transform.position.y > 20 && firstThreshold){
                nextLevel = false;
                transform.position = levelThree;
                secondThreshold = true;
                firstThreshold = false;
            } else if (transform.position.y > 20 && !firstThreshold){
                nextLevel = false;
                transform.position = levelTwo;
                firstThreshold = true;
            }
    }
}
