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
    public GameObject[] Menu;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LaunchSolo()
    {
        PlayerPrefs.SetString("GameType", "Solo");
        Menu[0].SetActive(false);
        Menu[1].SetActive(true);
        GameObject.Find("Circuit1").GetComponent<UnityEngine.UI.Button>().Select();
    }


    public void LaunchMulti()
    {
        PlayerPrefs.SetString("GameType", "Multi");
        Menu[0].SetActive(false);
        Menu[1].SetActive(true);
        GameObject.Find("Circuit1").GetComponent<UnityEngine.UI.Button>().Select();
    }

    public void LaunchCircuit(int map)
    {
        SceneManager.LoadScene(map);
    }

    public void ReturnToMenu()
    {
        Menu[0].SetActive(true);
        Menu[1].SetActive(false);
        GameObject.Find("Play_Solo").GetComponent<UnityEngine.UI.Button>().Select();
    }

    public void returnToStart()
    {
        SceneManager.LoadScene(0);
    }
}
