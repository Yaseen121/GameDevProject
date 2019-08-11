using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int LevelNumber;
    public Sprite lockedImage;
    public GameObject FadeSceneObject;
    private Fade FadeScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LevelNumber - 2 > 0)
        {
            if (levelsUnLocked[LevelNumber - 2])
            {
                FadeScript.FadeToLevel(LevelNumber);
                //SceneManager.LoadScene(LevelNumber);
            }
            else
            {
                Debug.Log("LEVEL IS LOCKED");
            }
        }
        else {
            FadeScript.FadeToLevel(LevelNumber);
            //SceneManager.LoadScene(LevelNumber);
        }
        
    }

    public bool[] levelsUnLocked; 

    private void Start()
    {
        FadeScript = FadeSceneObject.GetComponent<Fade>();
        Debug.Log("LOAD LEVEL AGAIN");
        levelsUnLocked = LevelController.control.levelsUnlocked;
        if (LevelNumber - 2 > 0)
        {
            Debug.Log("Level " + (LevelNumber-2));
            if (!levelsUnLocked[LevelNumber - 2])
            {
                Debug.Log(" Is Locked");
                gameObject.GetComponent<SpriteRenderer>().sprite = lockedImage;
            }
        }
    }

}
