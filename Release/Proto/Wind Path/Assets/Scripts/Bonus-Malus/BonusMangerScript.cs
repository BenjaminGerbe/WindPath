using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script fait par : Benjamin
/// Utilisé pour : Gérer les bonus et les malus
/// </summary>




[System.Serializable]
public struct Bonus
{
    public string name;
    public GameObject Object;

}

public class BonusMangerScript : MonoBehaviour
{
    
    
    [Header("Values")] 
    public List<Bonus> lstBonusMalus;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}



