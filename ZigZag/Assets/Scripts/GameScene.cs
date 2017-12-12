using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : MonoBehaviour {

    public GameObject gameOverPanel;

    //Colour Change
    public GameObject backgroundCircle;
    public Camera cam;
    public Color[] backgroundColors;
    public Color backgroundColor, backgroundColorDarken, temp;
    public float darken;

    private void Start()
    {
        GameManager.Instance.gameOver = false;
        backgroundColor = backgroundColors[Random.Range(0, backgroundColors.Length)];
        backgroundCircle.GetComponent<SpriteRenderer>().color = backgroundColor;

        temp = backgroundColor;
        darken = 1 + darken;
        backgroundColorDarken.r = temp.r *= darken;
        backgroundColorDarken.g = temp.g *= darken;
        backgroundColorDarken.b = temp.b *= darken;
        cam = FindObjectOfType<Camera>();
        cam.backgroundColor = backgroundColorDarken;
    }

    private void Update()
    {
        if(GameManager.Instance.gameOver == true)
            gameOverPanel.SetActive(true);
    }

    //Buttons
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
