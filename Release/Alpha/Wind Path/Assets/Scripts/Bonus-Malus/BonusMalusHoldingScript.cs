using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


public class BonusMalusHoldingScript : MonoBehaviour
{
    
    private List<BonusObject> LstBonus;
    
    private bool detect = false;
    private bool effect = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tonneau"))
        {
            detect = true;
        }
    }

    private void Start()
    {
        var arr = FindObjectsOfType<MonoBehaviour>().OfType<BonusObject>();
        LstBonus = new List<BonusObject>();
        
        foreach (var s in arr) {
            LstBonus.Add(s);
        }
        
    }

    public UnityEvent GenerateBonus(List<UnityEvent> Evt)
    {
        return Evt[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (LstBonus.Count >=2)
        {
            if (Input.GetButtonDown("Fire1") && detect)
            { 
                effect = true;
                detect = false;
            }

            if (effect )
            {
                
                LstBonus[0].Starteffect(this.transform);
                effect = false;

            }
        }

    }
}
