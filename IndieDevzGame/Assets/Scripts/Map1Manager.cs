using UnityEngine;

public class Map1Manager : MonoBehaviour
{
    void Start()
    {
        // Pontsz�m null�z�sa, ha �jraind�tjuk a j�t�kot
        ScoreManager.ResetScore();
        Debug.Log("Score Resetelve");
    }
}
