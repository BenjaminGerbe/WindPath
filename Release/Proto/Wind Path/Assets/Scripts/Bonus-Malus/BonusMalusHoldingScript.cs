using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BonusMalusHoldingScript : MonoBehaviour
{
    
    
    
    public BonusMangerScript BMS;
    
    private UnityEvent effect;
    private bool StartEffect;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tonneau"))
        {
            
            effect = GenerateBonus(BMS.lstEffectBonus);
           

        }
    }


    public UnityEvent GenerateBonus(List<UnityEvent> Evt)
    {
        return Evt[0];
    }
    
    // Start is called before the first frame update

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && effect != null)
        { 
            StartEffect = true;
          
        }

        if (StartEffect)
        {
            effect.Invoke();
        }
        
    }
}
