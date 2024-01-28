using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private static int totalScore = 0;
    private static TextMeshProUGUI totalScoreText;

    // Call this method to initialize the TextMeshProUGUI reference
    public static void Initialize(TextMeshProUGUI textComponent)
    {
        totalScoreText = textComponent;
        UpdateScoreText();
    }

    public static void AddScore(int points)
    {
        totalScore += points;
        UpdateScoreText();
    }

    private static void UpdateScoreText()
    {
        if (totalScoreText != null)
        {
            string scoreText = "Total Score: " + totalScore;

            if (totalScore < 0)
            {
                scoreText = "Total Score: " + totalScore;
            }

            totalScoreText.text = scoreText;
        }
        else
        {
            Debug.LogWarning("totalScoreText is null");
        }
    }
}