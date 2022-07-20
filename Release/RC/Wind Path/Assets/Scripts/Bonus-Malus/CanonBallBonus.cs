using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallBonus : MonoBehaviour,BonusObject
{

    public string NameOfBonus;
    public float TimeOfStuck = 3f;
    public float durationSplash;
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

            
            ParticleSystem p = r.getDetectedBoat().GetComponentInChildren<ParticleSystem>();
            if (p != null)
            {
                StartCoroutine(Splash(p,p.transform.GetChild(0)));      
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

            ParticleSystem p =  r.getDetectedBoat().GetComponentInChildren<ParticleSystem>();
         
            StartCoroutine(Splash(p,p.transform.GetChild(0)));
            StartCoroutine(Stuck());
            
            return true;
        }

        return false;
    }


    IEnumerator Splash(ParticleSystem PS,Transform go)
    {
        float count = this.durationSplash;
        var emissionModule = PS.emission;

        
        emissionModule.rateOverTime = 0;
        while (count >= 0 )
        {
            count -= Time.deltaTime;
            
            emissionModule.rateOverTime = 250;
            go.gameObject.SetActive(true);
            
            if (count < 0)
            {
                emissionModule.rateOverTime = 0;
                go.gameObject.SetActive(false);
            }
          
            
            
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator Stuck()
    {
        float count = this.TimeOfStuck;
   
        while (count >= 0 && BCS != null)
        {
            count -= Time.deltaTime;
          
            
            BCS.Stuck();

            if (count < 0)
            {
                BCS.setStuck(false);
            }

            yield return new WaitForFixedUpdate();
        }
    }
    
}
