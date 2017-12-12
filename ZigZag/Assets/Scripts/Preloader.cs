using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour {

    private CanvasGroup fadeGroup;
    private float loadtime;
    private float minimumLogoTime = 1.0f; //Minimum time of that scene

    private void Start()
    {
        //Grab the only CanvasGroup in the scene
        fadeGroup = FindObjectOfType<CanvasGroup>();

        //Start with white screen
        fadeGroup.alpha = 1;

        //Preload the game
        

        //Get the timestamp of the completion time, if loadtime is fast give a small buffer to see the logo
        if (Time.time < minimumLogoTime)
            loadtime = minimumLogoTime;
        else
            loadtime = Time.time;
    }

    private void Update()
    {
        //Fade in
        if (Time.time < minimumLogoTime)
            fadeGroup.alpha = 1 - Time.time;
        //Fade out
        if (Time.time > minimumLogoTime && loadtime != 0)
        {
            fadeGroup.alpha = Time.time - minimumLogoTime;
            if(fadeGroup.alpha >= 1)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

    }
}
