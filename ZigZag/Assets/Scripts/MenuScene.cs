using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour {

    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.33f; //Divide amount of time wanted for fade by 10

    private void Start()
    {
        //Grab the only CanvasGroup in the scene
        fadeGroup = FindObjectOfType<CanvasGroup>();

        //Start with white screen
        fadeGroup.alpha = 1;
    }

    private void Update()
    {
        //Fade in
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
    }

    //Buttons
    public void OnPlayClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnShopClick()
    {
        SceneManager.LoadScene("Shop");
    }

    public void OnResetClick()
    {
        SaveManager.Instance.ResetSave();
        SceneManager.LoadScene("Preloader");
    }
}
