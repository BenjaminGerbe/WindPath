
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Script fait par: Julien
    /// Utilisé pour : gestion de la pause
    /// </summary>
    private bool pause = false;
    public GameObject pauseMenu;
   

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;

            if (pause)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                pauseMenu.SetActive(false);
            }
        }
        
    }

    public void QuitRace()
    {
        Time.timeScale = 1.0f;
        
        if (RaceGestionScript.leaderboard != null)
        {
            RaceGestionScript.reset = true;
        }
        
        SceneManager.LoadScene(0);
        
      
        
    }
}
