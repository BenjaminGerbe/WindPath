using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwitchQuality : MonoBehaviour
{
    public TextMeshProUGUI text;
    public LanguageManager LM;
    
    private bool low = false;
    private bool hight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
       int d = PlayerPrefs.GetInt("Quality");
        
       
      if (d == 0)
      {
          text.text = LM.getStringByKey("Faible");
          low = true;
          hight = false;
          QualitySettings.SetQualityLevel(0);
      }
      else
      {
          text.text = LM.getStringByKey("Moyen");
          low = false;
          hight = true;
          QualitySettings.SetQualityLevel(2);
      }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeQuality()
    {
        low = !low;
        hight = !hight;

        if (low)
        {
            QualitySettings.SetQualityLevel(0);
            text.text = LM.getStringByKey("Faible");
            PlayerPrefs.SetInt("Quality",0);
        }
        
        

        if (hight)
        {
            QualitySettings.SetQualityLevel(2);
            text.text = LM.getStringByKey("Moyen");
            PlayerPrefs.SetInt("Quality",2);
        }
        
  
      
        
        Debug.Log(QualitySettings.GetQualityLevel());
    }
    
    
}
