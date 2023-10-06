using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public Transform player;
    float direction;
    public float forceMult = 2f; 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var direction = (player.transform.position - this.transform.position);
        rb.AddForce(Vector3.Normalize(direction * forceMult));

    }
}
