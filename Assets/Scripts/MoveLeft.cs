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



    private void Start()
    {
        speed = 15.0f;
        leftBound = -15.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.gameOver)
        {
            transform.Translate(Time.deltaTime * Vector3.left * speed);
        }

        if (gameObject.transform.position.x < leftBound && gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }

    }
}