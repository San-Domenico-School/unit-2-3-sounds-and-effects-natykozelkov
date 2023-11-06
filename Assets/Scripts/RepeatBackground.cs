using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/********************************************
 * Repeating GameObject "Background".
 * 
 * Naty Kozelkova
 * October 31, 2023 Version 1.0
 *******************************************/

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x /2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - repeatWidth)
        {
            gameObject.transform.position = startPos;
        }
    }


}
