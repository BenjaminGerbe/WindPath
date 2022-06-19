using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallBonus : MonoBehaviour,BonusObject
{

    public string NameOfBonus;
    public float TimeOfStuck = 3f;


    private BoatControlleurScript BCS;
    public string getName()
    {
        return NameOfBonus;
    }

    public void LoadEffect(Transform go)
    {
       
        go.GetComponent<LoadCanon>().OpenRange();
    }
    
    public void Starteffect(Transform go)
    {
        go.GetComponent<LoadCanon>().CloseRange();
        Range r =   go.GetComponent<LoadCanon>().range;
            
        r.Detect();
        
        if ( r.getDetectedBoat() != null)
        {
            BCS =r.getDetectedBoat().GetComponent<BoatControlleurScript>();
            StartCoroutine(Stuck(go));
        }
        
    }
    
    public bool StarteffectIA(Transform go)
    {
     
        Range r =   go.GetComponent<LoadCanon>().range;
            
        r.Detect();
        
        if ( r.getDetectedBoat() != null)
        {
            go.GetComponent<LoadCanon>().CloseRange();
            BCS =r.getDetectedBoat().GetComponent<BoatControlleurScript>();
            StartCoroutine(Stuck(go));
            
            return true;
        }

        return false;
    }
    
    
    IEnumerator Stuck(Transform go)
    {
        float count = this.TimeOfStuck;
   
        while (count >= 0 && BCS != null)
        {
            count -= Time.deltaTime;
          
      
            BCS.Stuck();
            
            yield return new WaitForFixedUpdate();
        }
    }
    
}
