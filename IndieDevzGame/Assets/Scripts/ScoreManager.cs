using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;  
    public TextMeshProUGUI scoreText;  

    void Start()
    {
        UpdateScoreDisplay();  
    }

    void Update()
    {
        UpdateScoreDisplay(); 
    }

    // A score frissítése
    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // A score növelése
    public static void AddScore(int points)
    {
        score += points;
    }

    public static void ResetScore()
    {
        score = 0;
    }
}
