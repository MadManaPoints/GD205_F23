using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public Material white; 

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Opp"){
            Destroy(gameObject); 
            Debug.Log("YOU WIN!"); 
        } else if (col.gameObject.tag == "Friendly"){
            Destroy(gameObject);
            Debug.Log("YOU LOSE"); 
        } else if (col.gameObject.tag == "Wall"){
            gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            gameObject.GetComponent<Renderer>().material = white;
        }
    }
}
