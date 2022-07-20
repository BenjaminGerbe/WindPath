using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing.MiniJSON;


[System.Serializable]
public class UILanguage
{
    public string Langue;
    public List<string> libraryWordsKeys;
    public List<string> libraryWords;

}

public class LanguageManager : MonoBehaviour
{
    

    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Traduction
    /// </summary>
    /// 
    
    static public int currentLangue = 1;
    
    
     public List<TextAsset> lstJsonPath;

     private List<UILanguage> lstLanguage;
    
    // Start is called before the first frame update
    void Awake()
    {
        
            
        
        lstLanguage = new List<UILanguage>();
        foreach (TextAsset TA in lstJsonPath)
        {
            lstLanguage.Add(JsonUtility.FromJson<UILanguage>(TA.text));
        }
        
        
        
        
        
        currentLangue = PlayerPrefs.GetInt("Langue");
        
    }



    
    public string getStringByKey(string key)
    {
        bool trouver = false;
        int i = 0;

        while (!trouver && i <= lstLanguage[currentLangue].libraryWordsKeys.Count)
        {
            if (lstLanguage[currentLangue].libraryWordsKeys[i] == key)
            {
                trouver = true;
            }
            else
            {
                i++;
            }
        }

        if (trouver == false)
        {
            Debug.LogError("la clé "+key + " n'a pas été trouvé");
        }


        return lstLanguage[currentLangue].libraryWords[i];
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
