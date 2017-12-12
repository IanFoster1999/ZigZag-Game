using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { set; get; }

    public bool gameOver = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }


}
