using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] runnerPrefabs;
    public float targetTime = 3.0f;
    private float spawnX = -70.0f; 
    private float spawnZ = 39.0f;
    private float [] shelves = new float [] {56.0f, 38.5f, 22.75f};
    void Start()
    {
        InvokeRepeating("SpawnRandomRunner", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {   
         
    }

    void SpawnRandomRunner(){
        int runnersIndex = Random.Range(0, runnerPrefabs.Length);
        int shelfIndex = Random.Range(0, shelves.Length);
        Vector3 spawnPos = new Vector3(spawnX, shelves[shelfIndex], spawnZ); 
        
        Instantiate(runnerPrefabs[runnersIndex], spawnPos, runnerPrefabs[runnersIndex].transform.rotation); 
    }
}
