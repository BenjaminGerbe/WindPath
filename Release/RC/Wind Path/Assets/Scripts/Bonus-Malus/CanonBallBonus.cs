using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallBonus : MonoBehaviour,BonusObject
{

    public string NameOfBonus;
    public float TimeOfStuck = 3f;
    public Sprite Cover;

    public Sprite getCover()
    {
        return this.Cover;
    }

    private BoatControlleurScript BCS;
    public string getName()
    {
        return NameOfBonus;
    }

    public void LoadEffect(Transform go)
    {
       
        go.GetComponent<LoadCanon>().OpenRange();
    }
    
    public void DisableEffect(Transform go)
    {
       
        go.GetComponent<LoadCanon>().CloseRange();
    }
    
    public void Starteffect(Transform go)
    {
        go.GetComponent<LoadCanon>().CloseRange();
        Range r =   go.GetComponent<LoadCanon>().range;
        
        
        
        r.Detect();
        
        if ( r.getDetectedBoat() != null)
        {
            BCS =r.getDetectedBoat().GetComponent<BoatControlleurScript>();
            BonusMalusHoldingScript BMS = r.getDetectedBoat().GetComponent<BonusMalusHoldingScript>();
            BonusMalusHoldingIAScript BMSIA = r.getDetectedBoat().GetComponent<BonusMalusHoldingIAScript>();

            if (BMS)
            {
                BMS.cancelBonus();
            }
            
            if (BMSIA)
            {
                BMSIA.cancelBonus();
            }

            
            StartCoroutine(Stuck());
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
            
            BonusMalusHoldingScript BMS = r.getDetectedBoat().GetComponent<BonusMalusHoldingScript>();
            BonusMalusHoldingIAScript BMSIA = r.getDetectedBoat().GetComponent<BonusMalusHoldingIAScript>();

            if (BMS)
            {
                BMS.cancelBonus();
            }
            
            if (BMSIA)
            {
                BMSIA.cancelBonus();
            }
            
            StartCoroutine(Stuck());
            
            return true;
        }

        return false;
    }
    
    
    IEnumerator Stuck()
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
