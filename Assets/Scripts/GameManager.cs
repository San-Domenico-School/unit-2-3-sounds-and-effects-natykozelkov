using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

/********************************************
 * The game manager can track and control the
 * game start, level initialization, game over,
 * restarting, scores, and timers.
 * 
 * Naty Kozelkova
 * November 27, 2023 Version 1.0
 *******************************************/

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreboardText, timeRemainingText;
    [SerializeField] private GameObject toggleGroup, startButton, spawnManager;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private ParticleSystem dirtSplatter;

    public static bool gameOver = true;
    private static float score;
    private AudioSource audioSource;
    private int timeRemaining = 60;
    private bool timedGame;
    private float spawnDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayUI();
        EndGame();
    }

    void DisplayUI()
    {

    }

    void TimeCountdown()
    {

    }

    public void StartGame()
    {
        audioSource.Play();
        toggleGroup.SetActive(false);
        startButton.SetActive(false);
        
        if (timedGame)
        {
            timeRemainingText.gameObject.SetActive(true);
            InvokeRepeating("TimeCountdown", spawnDelay, 1);
        }
        gameOver = false;
        spawnManager.SetActive(true);
        playerAnimator.SetBool("BeginGame_b", true);
        dirtSplatter.Play();
    }

    void EndGame()
    {

    }

    public void SetTimed (bool timed)
    {

    }

    public static void ChangeScore (int change)
    {

    }

}
