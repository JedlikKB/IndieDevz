using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Itt kell beállítani a jelenetet, amit el akarunk indítani
        SceneManager.LoadScene("Map1Scene");
    }
    public void RestartGame()
    {
        // Játék újraindítása (ugyanaz egyenlőre mint a start game)
        SceneManager.LoadScene("Map1Scene");
    }

    public void GoToMainMenu()
    {
        // Vissza a főmenübe
        SceneManager.LoadScene("MainMenu");
    }
}
