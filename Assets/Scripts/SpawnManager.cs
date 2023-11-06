using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/********************************************
 * Component of SpawnManager, spawns obstacles
 * into the scene.
 * 
 * Naty Kozelkova
 * October 31, 2023 Version 1.0
 *******************************************/

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;

    private PlayerController playerControllerScript;
    private Vector3 spawnPos;
    private float startDelay;
    private float repeatRate;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(25, 0, 0);
        startDelay = 2.0f;
        repeatRate = 2.0f;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        else
        {
            CancelInvoke();
        }

    }
    
}
