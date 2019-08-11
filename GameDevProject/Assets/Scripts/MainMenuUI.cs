using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button LevelSelectButton;
    public GameObject FadeSceneObject;
    public GameObject ControlPanel;
    private Fade FadeScript;
    private GameObject previousSelected;

    void Start()
    {
        ControlPanel.SetActive(false);
        FadeScript = FadeSceneObject.GetComponent<Fade>();
        LevelSelectButton.Select();
    }


    //Reference Brackeys Fade secnes https://www.youtube.com/watch?v=Oadq-IrOazg
    public void levelSelectPressed() {
        FadeScript.FadeToLevel(1);
    }

    //SceneManager.LoadScene(1);

    public void controlsPressed() {
        //Make a scene showing controls
        previousSelected = EventSystem.current.currentSelectedGameObject; 
        ControlPanel.SetActive(true);
    }

    public void closeControlPanel() {
        ControlPanel.SetActive(false);
        LevelSelectButton.Select();
    }

    public void quitPressed() {
        Application.Quit();
    }
}
