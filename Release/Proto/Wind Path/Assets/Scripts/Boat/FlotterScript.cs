using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlotterScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par: Benjamin
    /// Utilisé pour : simuler un effet de flottement 
    /// </summary>


    [Header("Conpenents")] 
    public Rigidbody RB;
    public Transform Flotteur;
    public LayerMask WaterMask;
    public float offset = 15f;
  
   
    
    // Start is called before the first frame update
    void Start()
    {
      
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
   
        float value = -100;

        RaycastHit hit;
        Ray r = new Ray(new Vector3(Flotteur.position.x, Flotteur.position.y + 10, Flotteur.position.z),Vector3.down);

        Debug.DrawRay(new Vector3(Flotteur.position.x, Flotteur.position.y + 10, Flotteur.position.z),Vector3.down * 50f);
        
        
        if (Physics.Raycast(r,out hit,50f,WaterMask))
        {
            Debug.Log("hallo");
            value = hit.point.y;
        }


        Debug.Log(value);
        
        

         if (Flotteur.position.y < 50)
         {
             RB.AddForce(new Vector3(0,-Flotteur.position.y * 100,0));
         }
    }


  
}
