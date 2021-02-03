using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;


    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    int score;

    private void Awake()
    {
        instance = this;
    }

    public void AddPoints(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score;
    }
}
