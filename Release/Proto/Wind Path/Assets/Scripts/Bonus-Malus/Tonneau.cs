using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Tonneau : MonoBehaviour
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Permet de gerer le bonus du tonneau
    /// </summary>
    

    [Header("Values")] 
    public float Timer;

    public BoatControlleurScript BCS;
    public float Speed;
    public float maxSpeed;
    
    private bool starteffect;
    private float Counter;
    private Rigidbody RB;
    private float oldmaxSpeed;

    
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
        oldmaxSpeed = BCS.MaxVitesse;

        Counter = Timer;
    
    }
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (starteffect)
        {
           
            Counter -= Time.fixedDeltaTime;
            
            RB.AddForce(RB.transform.forward * Speed, ForceMode.Acceleration );
            BCS.MaxVitesse = maxSpeed;
            
            if (Counter < 0)
            {
                
                BCS.MaxVitesse = oldmaxSpeed;
               
                starteffect = false;
                Destroy(this.gameObject);
            }
            
        }
        
        
    }
}
