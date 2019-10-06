﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool InMenu = false;

    public GameObject mainUI;
    public GameObject pauseMenuUI;
    public GameObject startMenuUI;
    public GameObject endGameScreenUI;
    public GameObject winGameScreenUI;

    public Text menuCounterText;
    public Text pauseCounterText;

    private int count;
    public int countValue = 1;
    public int maxCountValue = 12;

    // Start is called before the first frame update
    void Start()
    {
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) {
                ResumeGame();
            }
            else {
                if (!InMenu)
                {
                    PauseGame();
                }
            }
        }
    }

    // Helpers

    public void Pause() {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Play() {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Counter()
    {
        count = count + countValue;
        menuCounterText.text = menuCounterText.text + count;
        pauseCounterText.text = pauseCounterText.text + count;
        CheckGameState();
    }

    public void CheckGameState() {
        if (count >= maxCountValue)
        {
            GameWin();
        }
    }

    // Helpers


    // Pause Menu
    public void ResumeGame() {
        pauseMenuUI.SetActive(false);
        mainUI.SetActive(true);
        Play();
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        mainUI.SetActive(false);
        Pause();
    }
    // Pause Menu

    // Game State Menu
    public void GameOver()
    {
        endGameScreenUI.SetActive(true);
        mainUI.SetActive(false);
        Pause();
    }

    public void GameWin()
    {
        winGameScreenUI.SetActive(true);
        mainUI.SetActive(true);
        Pause();
    }

    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Game State Menu

    public void MainMenu()
    {
        startMenuUI.SetActive(true);
        mainUI.SetActive(false);
        Pause();
    }

    public void StartGame()
    {
        startMenuUI.SetActive(false);
        mainUI.SetActive(true);
        Play();
    }
}