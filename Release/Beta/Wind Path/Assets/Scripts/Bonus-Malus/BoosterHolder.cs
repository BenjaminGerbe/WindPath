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
    public float Speed;
    private Rigidbody RB;
    
    
    private void Start()
    {
      
    }
    
    public void Starteffect(Transform go)
    {
        this.RB = go.gameObject.GetComponent<Rigidbody>();
        StartCoroutine(Boost(go));
        
    }
    
    public string getName()
    {
        return NameOfBonus;
    }
    
    IEnumerator Boost(Transform go)
    {
        float count = this.TimerBoost;
   
        while (count >= 0 && this.RB != null)
        {
            count -= Time.deltaTime;
          
            this.RB.AddForce(this.RB.transform.forward * Speed, ForceMode.Acceleration );
            
            yield return new WaitForFixedUpdate();
        }
    }
    
    

}
