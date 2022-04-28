using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBonus : MonoBehaviour
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Permet de gerer le bonus du Wind
    /// </summary>
    
    
    private WindControl WC;
    
    
    private bool starteffect = false;
    private Rigidbody RB;
    private Transform targetTranform;
    
    private void OnTriggerEnter(Collider other)
    {
     
        targetTranform = other.transform;
        starteffect = true;
        
    }

    private void Start()
    {
        WC = GameObject.FindObjectOfType<WindControl>();
    }
    
    // Update is called once per frame
    void Update()
    {  
        
        if (starteffect)
        {
            
            this.transform.parent.GetComponent<TonneauSpawnerScript>().Spawn();
            WC.ForceSetWind(new Vector3(targetTranform.forward.x,targetTranform.forward.z));
            starteffect = false;
            Destroy(this.gameObject);
        }
        
    }
}
