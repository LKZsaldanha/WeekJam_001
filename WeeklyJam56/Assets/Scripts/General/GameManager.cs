﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public enum UIState { START, TUTORIAL, GAME, PAUSE, END };

public class GameManager : MonoBehaviour {

    public bool soundOn = true;

    public bool allowGameplayInputs = false;

    private bool isPaused = false;    

    private float previousTimeScale;
    private float previousFixedDeltaTime;

    public UIState uiState = UIState.START;
    public bool gameStarted = false;

    private void Start()
    {
        previousTimeScale = Time.timeScale;
        previousFixedDeltaTime = Time.fixedDeltaTime;

        LoadGameInfo();
        ApplySoundConfig();
    }

    private void Update()
    {
        if (gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPaused)
                { 
                    PauseGame();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (soundOn)
            {
                MuteSound();
            }
            else
            {
                ResumeSound();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void EndGame()
    {
        uiState = UIState.END;
        allowGameplayInputs = false;
    }
    
    public void StartGame()
    {
        gameStarted = true;
        allowGameplayInputs = true;
        uiState = UIState.GAME;
    }

    public void PauseGame()
    {
        isPaused = true;
        allowGameplayInputs = false;

        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;

        previousFixedDeltaTime = Time.fixedDeltaTime;
        Time.fixedDeltaTime = 0f;
        uiState = UIState.PAUSE;
}

    public void UnpauseGame()
    {
        Time.timeScale = previousTimeScale;
        Time.fixedDeltaTime = previousFixedDeltaTime;

        isPaused = false;
        allowGameplayInputs = true;
        uiState = UIState.GAME;
    }

    public void MuteSound()
    {
        soundOn = false;
        ApplySoundConfig();
    }

    public void ResumeSound()
    {
        soundOn = true;
        ApplySoundConfig();
    }

    public void ApplySoundConfig()
    {
        if (soundOn)
        {
            AudioListener.pause = false;
        }
        else
        {
            AudioListener.pause = true;
        }
    }

    public void PlayAgain()
    {
        RestartLevel();
    }

    private void RestartLevel()
    {
        SaveGamgeInfo();
        Time.timeScale = previousTimeScale;
        Time.fixedDeltaTime = previousFixedDeltaTime;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SaveGamgeInfo()
    {
        SaveSound(soundOn);
    }

    private void LoadGameInfo()
    {
        soundOn = LoadSound();
    }

    #region SAVE GAME FUNCTIONS
    private void SaveHighScore(int _value)
    {
        PlayerPrefs.SetInt("HighScore", _value);
    }
      

    private void SaveSound (bool _isOn)
    {
        if (_isOn)
        {
            PlayerPrefs.SetInt("SoundOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SoundOn", 0);
        }
    }
    #endregion

    #region LOAD GAME FUNCTIONS
    private int LoadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    private bool LoadSound()
    {
        int isOn = PlayerPrefs.GetInt("SoundOn");
        return isOn == 1;
    }

    #endregion
}
