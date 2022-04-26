using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script fait par: Julien
/// Utilisé pour : gestion du menu principal
/// </summary>

public class MainMenuScript : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LaunchSolo()
    {
        PlayerPrefs.SetString("GameType", "Solo");
        SceneManager.LoadScene(1);
    }

    public void LaunchMulti()
    {
        PlayerPrefs.SetString("GameType", "Multi");
        SceneManager.LoadScene(1);
    }
}
