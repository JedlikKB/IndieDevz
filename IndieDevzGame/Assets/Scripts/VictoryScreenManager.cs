using UnityEngine;
using TMPro;

public class VictoryScreenManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        // Végső pontszám megjelenítése
        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + ScoreManager.score.ToString();
        }
    }
}
