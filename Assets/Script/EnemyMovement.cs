using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float targetTime = 1.0f;
    public float moveForward = 1.0f; 
    public float moveBackward = -1.0f;
    Vector3 moveEnemy; 
    void Start()
    {
        moveEnemy = new Vector3(0f, 0f, moveForward);
    }

    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f){
            timerEnded();
        }

        if (transform.position.z > 6){
            moveEnemy = new Vector3(0f, 0f, moveBackward);
        }
        if (transform.position.z < 3){
            moveEnemy = new Vector3(0f, 0f, moveForward);
        }
    }

    void timerEnded(){
        transform.position += moveEnemy;
        targetTime = 1.0f;
    }
}
