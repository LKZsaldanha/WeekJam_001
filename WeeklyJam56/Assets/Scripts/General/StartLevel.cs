using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour {

    public Text instructionsText;
    public bool LastLevel = false;

    void Start()
    {
        if (!LastLevel)
        {
            instructionsText.text = "Press any key to start";
        }
        else
        {
            instructionsText.text = "Press any key to restart";
        }
            
        instructionsText.enabled = true;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            instructionsText.enabled = false;
            if (LastLevel)
            {
                SceneManager.LoadScene("SampleScene 2");
            }
        }
    }
}
