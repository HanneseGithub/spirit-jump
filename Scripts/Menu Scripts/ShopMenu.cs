using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    private int totalScore;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        scoreText.text = totalScore + " POINTS";
    }
}
