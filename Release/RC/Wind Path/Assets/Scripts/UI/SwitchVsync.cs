using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwitchVsync : MonoBehaviour
{
    public TextMeshProUGUI t;
    public LanguageManager LM;
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
            t.text = LM.getStringByKey("Disactiver");
        }
        else
        {
            enable = true;
            t.text = LM.getStringByKey("Activer");
        }
    
    }

    public void enableVsync()
    {
        if (!enable)
        {
            QualitySettings.vSyncCount = 1;
            enable = true;
            PlayerPrefs.SetInt("Vsync",2);
            t.text = LM.getStringByKey("Activer");
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            enable = false;
            PlayerPrefs.SetInt("Vsync",0);
            t.text = LM.getStringByKey("Disactiver");
        }
      
    }
}
