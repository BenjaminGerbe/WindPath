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

    
    private void OnTriggerEnter(Collider other)
    {
     
        starteffect = true;
        
        if (other.GetComponent<Rigidbody>())
        {
            RB = other.GetComponent<Rigidbody>();
        }

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

   
        this.GetComponent<Collider>().enabled = false;
    }

    private void Start()
    {
        WC = GameObject.FindObjectOfType<WindControl>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {  
        
        if (starteffect)
        {
            this.transform.parent.GetComponent<TonneauSpawnerScript>().Spawn();
            WC.SetVectorWind(RB.transform.forward);
            starteffect = false;
            Destroy(this.gameObject);
        }
        
    }
}
