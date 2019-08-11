using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Animator animator;
    int levelToLoad;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel(int lvl)
    {
        levelToLoad = lvl;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
    }
}
