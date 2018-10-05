using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour {

    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minimumLoadTime = 3.5f;

    private void Start()
    {
        fadeGroup = FindObjectOfType<CanvasGroup>();

        fadeGroup.alpha = 1;

        //pre load game 
        //$$

        if (Time.time < minimumLoadTime)
            loadTime = minimumLoadTime;
        else
            loadTime = Time.time;

    }

    private void Update()
    {
        if(Time.time < minimumLoadTime)
        {
            fadeGroup.alpha = 1 - Time.time;
        }

        if (Time.time > minimumLoadTime && loadTime != 0)
        {
             fadeGroup.alpha = Time.time - minimumLoadTime;
            if (fadeGroup.alpha >=1)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}
