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

    public float Speed;
    
    
    private bool starteffect;
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

    void DesactiveBonus()
    {
     
    }
    
    // Update is called once per frame
    void Update()
    {
        if (starteffect)
        {
            Debug.Log("salut");
            Counter -= Time.deltaTime;
            
            RB.AddForce(RB.transform.forward * Speed, ForceMode.Acceleration );
            
            
            if (Counter < 0)
            {
                
                starteffect = false;
                Destroy(this.gameObject);
            }
            
        }
    }
}
