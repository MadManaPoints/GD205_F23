using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclops : MonoBehaviour
{
    public GameObject prefab;
    public GameObject ball; 
    public float boomForce = 750f;
    public float boomRad = 60f;
    public Material red; 

    void Start()
    {

    }

    void Update()
    {
        Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(laser, out hit)){
            //Debug.Log("You hit something " + hit.collider.gameObject.name);
            if (Input.GetMouseButtonDown(0) && hit.rigidbody && hit.rigidbody.tag != "Opp" && hit.rigidbody.tag != "Friendly"){
                hit.collider.gameObject.GetComponent<Renderer>().material = red;
                hit.rigidbody.AddExplosionForce(boomForce, hit.point, boomRad);
                Instantiate(ball, new Vector3(hit.collider.gameObject.transform.position.x, 45.0f, hit.collider.gameObject.transform.position.z), hit.rigidbody.transform.rotation);
            }
            //if (Input.GetMouseButtonDown(1) && hit.rigidbody){
            //  Instantiate(prefab, new Vector3(0f, 15f, 0f), Quaternion.identity);}
        }
    }
}
