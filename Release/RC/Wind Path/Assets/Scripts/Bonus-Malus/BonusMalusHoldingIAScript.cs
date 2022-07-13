using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


public class BonusMalusHoldingIAScript : MonoBehaviour
{
    
    private List<BonusObject> LstBonus;
    
    private bool detect = false;
    private bool effect = false;

    private int indexObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tonneau") && !detect)
        {
       
            detect = true;
            indexObject = Random.Range(0, LstBonus.Count);
            other.gameObject.GetComponentInParent<TonneauSpawnerScript>().Spawn();
            LstBonus[indexObject].LoadEffect(this.transform);
            
            
            Destroy(other.gameObject);
    
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

            if (detect)
            {

                if (LstBonus[indexObject] is CanonBallBonus)
                {
                    if ( (LstBonus[indexObject] as CanonBallBonus).StarteffectIA(this.transform)  )
                    {
                        detect = false;
                    }
                }
                else
                {
                    
                    LstBonus[indexObject].Starteffect(this.transform);
                    detect = false;
                }
               
            }
           
            
        }

    }
}
