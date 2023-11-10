using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/********************************************
 * GameObject "Player" stays in one place while his background is moving.
 * 
 * Naty Kozelkova
 * October 31, 2023 Version 1.0
 *******************************************/

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce, gravityModifier;
    [SerializeField] private ParticleSystem explosionParticle, dirtParticle;
    [SerializeField] private AudioClip jumpSound, crashSound;

    private Animator playerAnimation;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private bool isOnGround;
    public bool gameOver { get; private set; }

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        isOnGround = true;
        Physics.gravity *= gravityModifier;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnJump(InputValue input)
    {
        if(isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimation.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.name == "Ground")
        {
            isOnGround = true;
        }
       else if (collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
      
       
    }
}
