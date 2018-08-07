﻿using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject startPanel;
    public GameObject pausePanel;
    public GameObject tutorialPanel;
    public GameObject gamePanel;
    public GameObject endPanel;

    private GameManager gm;
    private UIState currentUIState;

    public Text highScoreLabel;
    public Text endCurrentScoreLabel;

    public GameObject ResumeSoundButton;
    public GameObject MuteSoundButton;
    public GameObject QuitButton;

    private void Start ()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(gm.uiState != currentUIState)
        {
            SetActiveUI();
        }
    }

    public void UIUpdateInfo()
    {
        //setar visual dos botões de audio
        MuteSoundButton.SetActive(gm.soundOn);
        ResumeSoundButton.SetActive(!gm.soundOn);
    }

    private void SetActiveUI()
    {
        startPanel.SetActive(false);
        pausePanel.SetActive(false);
        tutorialPanel.SetActive(false);
        gamePanel.SetActive(false);
        endPanel.SetActive(false);

        switch (gm.uiState)
        {
            case UIState.START:
                startPanel.SetActive(true);
                break;
            case UIState.PAUSE:
                pausePanel.SetActive(true);
                break;
            case UIState.TUTORIAL:
                tutorialPanel.SetActive(true);
                break;
            case UIState.GAME:
                gamePanel.SetActive(true);
                break;
            case UIState.END:
                endPanel.SetActive(true);
                break;
        }
        currentUIState = gm.uiState;
        UIUpdateInfo();
    }
}
