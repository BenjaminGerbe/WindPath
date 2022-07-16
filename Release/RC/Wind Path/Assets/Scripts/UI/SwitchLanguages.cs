using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwitchLanguages : MonoBehaviour
{
    /// <summary>
    /// switch qui permet de switche entre le francais et l'anglais 
    /// </summary>
    public TextMeshProUGUI T;
    
    // Start is called before the first frame update
    void Start()
    {
        if (  LanguageManager.currentLangue  == 0)
        {
            T.text = "Français";
            
        }
        else
        {
            T.text = "English";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void changeLangue()
    {
        if (  LanguageManager.currentLangue  == 0)
        {
            LanguageManager.currentLangue = 1;
            T.text = "English";
            
            PlayerPrefs.SetInt("Langue",1);
        }
        else
        {
            LanguageManager.currentLangue = 0;
            T.text = "Français";
            
            PlayerPrefs.SetInt("Langue",0);
        }
        
      
   
    }
    
}
