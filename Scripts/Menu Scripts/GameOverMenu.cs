using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    private int score;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = score + " POINTS";
    }
}
