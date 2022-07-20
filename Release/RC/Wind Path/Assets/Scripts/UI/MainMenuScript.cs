using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// Script fait par: Julien et benjamin
/// Utilisé pour : gestion du menu principal
/// </summary>
///



[Serializable]
public struct levelOfMenu
{
    public GameObject Panel;
    public UnityEngine.UI.Button FirstButton;
}

public class MainMenuScript : MonoBehaviour
{

     
    
    public List<levelOfMenu> lstLOM;

    private int currentLevel = -1;
    private int currentCircuit = 1;
    void Start()
    {
 
        nextLevelMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex +1)% (SceneManager.sceneCountInBuildSettings));
        }
        
        
            
            
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
       
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex +1)% (SceneManager.sceneCountInBuildSettings));
        
    }

    public void ChooseCircuit(int i)
    {
     
        currentCircuit = i;
        nextLevelMenu();
    }


    public void nextLevelMenu()
    {
        if (lstLOM.Count > 0)
        {
         
            currentLevel = (currentLevel+1) % lstLOM.Count;

            lstLOM.ForEach(x =>  x.Panel.SetActive(false));
        
            lstLOM[currentLevel].Panel.SetActive(true); 
            lstLOM[currentLevel].FirstButton.Select();    
        }
        
    }
    
    public void beforeLevelMenu()
    {
        currentLevel = (currentLevel-1) % lstLOM.Count;

        lstLOM.ForEach(x =>  x.Panel.SetActive(false));
        
        lstLOM[currentLevel].Panel.SetActive(true);
        lstLOM[currentLevel].FirstButton.Select();

    }
    
    
    public void LaunchSolo()
    {
        PlayerPrefs.SetString("GameType", "Solo");
        nextLevelMenu();
 
    }


    public void LaunchMulti()
    {
        PlayerPrefs.SetString("GameType", "Multi");
        nextLevelMenu();

    }
    
    public void setDifficulty(int i)
    {
        PlayerPrefs.SetInt("Difficulty", i);
        nextLevelMenu();
    }
    

    public void LaunchCircuit()
    {
        SceneManager.LoadScene(currentCircuit);
    }
    
    
    public void ReturnToMenu()
    {
        nextLevelMenu();
        GameObject.Find("Play_Solo").GetComponent<UnityEngine.UI.Button>().Select();
    }

    public void returnToStart()
    {
        SceneManager.LoadScene(0);
    }
}
