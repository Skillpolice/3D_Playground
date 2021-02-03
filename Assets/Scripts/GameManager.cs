using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score;

    public void AddPoints(int addScore)
    {
        score += addScore;
    }
}
