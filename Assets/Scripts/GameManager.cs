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
        scoreboardText.text = "Score: " + Mathf.RoundToInt(score).ToString();
        if (timedGame && !gameOver)
        {
            if(timeRemaining > 0)
            {
                timeRemainingText.text = timeRemaining.ToString();
            }
            else
            {
                timeRemainingText.text = "Game\nOver";
            }
        }
    }

    void TimeCountdown()
    {
        timeRemaining--; 
        if (timeRemaining <= 0)
        {
            CancelInvoke("TimeCountdown");
        }
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
        playerAnimator.SetFloat("Speed_f", 1.0f);
        dirtSplatter.Play();
    }

    void EndGame()
    {
        if (gameOver || timeRemaining == 0)
        {
            gameOver = true;
            playerAnimator.SetBool("BeginGame_b", false);
            playerAnimator.SetFloat("Speed_f", 0);
            audioSource.Stop();
            CancelInvoke();
            timeRemainingText.text = "Game\nOver";
        }
    }

    public void SetTimed (bool timed)
    {
        Debug.Log("Is game over?");
        timedGame = timed;
    }

    public static void ChangeScore (int change)
    {
        score += change;
    }

}
