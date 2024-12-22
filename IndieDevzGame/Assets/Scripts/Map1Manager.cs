using UnityEngine;

public class Map1Manager : MonoBehaviour
{
    void Start()
    {
        // Pontszám nullázása, ha újraindítjuk a játékot
        ScoreManager.ResetScore();
        Debug.Log("Score Resetelve");
    }
}
