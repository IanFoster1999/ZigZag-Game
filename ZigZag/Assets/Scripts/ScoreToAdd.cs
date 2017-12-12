using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreToAdd : MonoBehaviour {

    public int scoreToAdd = 1;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            scoreManager.scoreCount += scoreToAdd;

            SaveManager.Instance.state.coins++;
            SaveManager.Instance.Save();
        }
    }
}
