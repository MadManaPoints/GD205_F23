using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementH : MonoBehaviour
{
   public float targetTime = 2.0f;
    public float moveLeft = -1.0f; 
    public float moveRight = 1.0f;
    Vector3 moveEnemy; 
    void Start()
    {
        moveEnemy = new Vector3(moveRight, 0f, 0f);
    }

    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f){
            timerEnded();
        }

        if (transform.position.x == 7){
            moveEnemy = new Vector3(moveLeft, 0f, 0f);
        }
        if (transform.position.x == 6){
            moveEnemy = new Vector3(moveRight, 0f, 0f);
        }
    }

    void timerEnded(){
        transform.position += moveEnemy;
        targetTime = 2.0f;
    }
}
