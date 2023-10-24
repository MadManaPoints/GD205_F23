using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    private float boundary = 70.0f; 
    private float bottomBoundary = 15f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > boundary){
            Destroy(gameObject); 
        }

        if (transform.position.y < bottomBoundary){
            Destroy(gameObject);
        }
    }
}
