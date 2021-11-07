using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreLabel;
    private int score = 0;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreLabel.text = "SCORE: " + score;
        }
    }
}