using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwitchVsync : MonoBehaviour
{
    public TextMeshProUGUI t;
    private bool enable = true;
    
    // Start is called before the first frame update
    void Start()
    {
           
        int d = PlayerPrefs.GetInt("Vsync");

        if (PlayerPrefs.HasKey("Vsync"))
        {
            d = 1;
        }
        
        QualitySettings.vSyncCount = d;

        if (d == 0)
        {
            enable = false;
            t.text = "désactiver";
        }
        else
        {
            enable = true;
            t.text = "activer";
        }
    
    }

    public void enableVsync()
    {
        if (!enable)
        {
            QualitySettings.vSyncCount = 1;
            enable = true;
            PlayerPrefs.SetInt("Vsync",2);
            t.text = "activer";
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            enable = false;
            PlayerPrefs.SetInt("Vsync",0);
            t.text = "désactivier";
        }
      
    }
}
