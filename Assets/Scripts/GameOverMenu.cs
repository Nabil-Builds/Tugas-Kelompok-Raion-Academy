using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public string gameplaySceneName = "Gameplay";
    public string mainMenuSceneName = "MainMenu";

    void Start()
    {
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Restart()
    {
        string target = string.IsNullOrEmpty(GameOverData.lastSceneName)
            ? gameplaySceneName
            : GameOverData.lastSceneName;
        SceneManager.LoadScene(target);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}