using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterHolder : MonoBehaviour,BonusObject
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Permet de gérer le booster
    /// </summary>

    public string NameOfBonus;
    public float TimerBoost;
    
    
    private void Start()
    {
      
    }
    
    public void Starteffect(Transform go)
    {
  
        StartCoroutine(Boost(go));
    }
    
    public string getName()
    {
        return NameOfBonus;
    }
    
    IEnumerator Boost(Transform go)
    {
        float count = this.TimerBoost;
        Debug.Log(count);
        while (count >= 0)
        {
            count -= Time.deltaTime;
            
            
            yield return new WaitForFixedUpdate();
        }
    }
    
    

}
