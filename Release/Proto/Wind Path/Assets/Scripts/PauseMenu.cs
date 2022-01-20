using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Script fait par: Julien
    /// Utilisé pour : gestion de la pause
    /// </summary>
    private bool pause = false;
    private GUIStyle Style = new GUIStyle();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;

            if (pause)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }

    void OnGUI()
    {
        if(pause)
        {
            Style.fontSize = 25;
            GUI.Label(new Rect(Screen.width/2-60, Screen.height/8, 100, 40), "PAUSE",Style);
        }
        
    }
}
