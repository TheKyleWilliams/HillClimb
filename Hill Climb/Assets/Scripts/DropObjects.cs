using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjects : MonoBehaviour
{
    // this finna be a boulder
    public GameObject fallingObject;

    // drop object every second
    public float spawnInterval = 1.0f;
    private float spawnIntervalSubtractor = 0.1f;
    private int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        // load level
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }

        currentLevel = PlayerPrefs.GetInt("CurrentLevel");

        // reduce spawn interval based on level
        spawnIntervalSubtractor = spawnIntervalSubtractor * currentLevel;
        spawnInterval = spawnInterval - spawnIntervalSubtractor;

        // repeatedly run the 'SpawnObject' starting at the 0th second and repeating 
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject() {
        // create random spawn position (within constraints)
        Vector3 spawnPosition = new Vector3(Random.Range(-9.5f, 9.5f), 50f, Random.Range(150f, 198f));
        Instantiate(fallingObject, spawnPosition, Quaternion.Euler(0, 0, -90));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
