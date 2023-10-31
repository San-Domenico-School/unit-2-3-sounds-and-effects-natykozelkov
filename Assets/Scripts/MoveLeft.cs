using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/********************************************
 * GameObject "Obstacle" and "Background" move.
 * 
 * Naty Kozelkova
 * October 31, 2023 Version 1.0
 *******************************************/

public class MoveLeft : MonoBehaviour
{
    private float speed;
    private float leftBound;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
        leftBound = -15f;
    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(Time.deltaTime * Vector3.left * speed);
    }
}
