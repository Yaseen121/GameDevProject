using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour
{
    private bool paused;
    public bool start=false;

    public GameObject pausePanel;
    public Button resumeButton;
    //public GameObject controlsPanel;

    private void Start()
    {
        //Make this true after trap selection finished
        pausePanel.SetActive(false);
        //controlsPanel.SetActive(false);
        paused = false;
        highlightResumeButton = false;
    }

    bool highlightResumeButton; 
    // Update is called once per frame
    void Update()
    {
        if (start) {
            if (Input.GetButtonDown("Cancel"))
            {
                paused = !paused;
            }
            if (paused)
            {
                //Debug.Log("Paused");
                pausePanel.SetActive(true);
                Time.timeScale = 0;
                if (!highlightResumeButton) {
                    highlightResumeButton = true;
                    resumeButton.Select();
                }
            }
            else
            {
                //Debug.Log("Resumed");
                pausePanel.SetActive(false);
                Time.timeScale = 1;
                highlightResumeButton = false;
            }
        }
    }

    public void resumePressed() {
        paused = false;
    }

    public void openControlsMenu() {
        //controlsPanel.SetActive(true);
    }

    public void mainMenuPressed() {
        SceneManager.LoadScene("MainMenu");
    }
}
