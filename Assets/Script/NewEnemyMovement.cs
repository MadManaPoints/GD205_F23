using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyMovement : MonoBehaviour
{
    public float targetTime = 1.0f;


    public bool moveX = true; 
    public bool moveZ = true;


    public float min = 0f; 
    public float max = 0f; 

    public float moveForward = 1f; 
    public float moveBackward = -1f; 


    public Vector3 moveEnemy = new Vector3(0f, 0f, 0f);


    void Start()
    {
        
    }

    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f){
            timerEnded();
        }

        if (moveX){
            if (transform.position.x > max){
                moveEnemy = new Vector3(moveBackward, 0f, 0f);
            }
            if (transform.position.x < min){
                moveEnemy = new Vector3(moveForward, 0f, 0f);
            }
        }

        if (moveZ){
            if (transform.position.z > max){
                moveEnemy = new Vector3(0f, 0f, moveBackward);
            }
            if (transform.position.z < min){
                moveEnemy = new Vector3(0f, 0f, moveForward);
            }
        }
    }

    void timerEnded(){
        transform.position += moveEnemy;
        targetTime = 1.0f;
    }
}
