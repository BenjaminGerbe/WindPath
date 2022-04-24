using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Booster : MonoBehaviour
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Permet de gerer le bonus du tonneau
    /// </summary>
    

    [Header("Values")] 
    public float Timer;
    public float Speed;

    private bool starteffect = false;
    private float Counter;
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


    // Start is called before the first frame update
    void Start()
    {
      
        Counter = Timer;
    
    }
    
    
    // Update is called once per frame
    void FixedUpdate()
    {  
        
        if (starteffect)
        {
           
            Counter -= Time.fixedDeltaTime;
            
            RB.AddForce(RB.transform.forward * Speed, ForceMode.Acceleration );
            
            
            if (Counter < 0)
            {
                this.transform.parent.GetComponent<TonneauSpawnerScript>().Spawn();
                starteffect = false;
                //Destroy(this.gameObject);
            }
            
        }
        
    }
}
