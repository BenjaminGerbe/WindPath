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

    private Vector3 directionToFloat;
    private Vector3 FlooterPoint;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    public Vector3 getNormalSurface()
    {
        return directionToFloat;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
   
        float value = -100;
        FlooterPoint = Vector3.zero;
        RaycastHit hit;
        Ray r = new Ray(new Vector3(Flotteur.position.x, Flotteur.position.y +  offset, Flotteur.position.z),Vector3.down);
        
        
        if (Physics.Raycast(r,out hit,50f,WaterMask))
        {
            
            value = hit.point.y;
            FlooterPoint = hit.normal;
        }


        directionToFloat = Vector3.Cross(Flotteur.right, FlooterPoint);
        Debug.DrawRay(this.transform.position,directionToFloat*100f,Color.yellow);
        if (Flotteur.position.y < value)
        {
            float v = (value - Flotteur.position.y) * 70;
            RB.AddForce(new Vector3(FlooterPoint.x * v, FlooterPoint.y * v, FlooterPoint.z * v));
        }
        else  if (Flotteur.position.y  > value + 1)
        {
            Debug.Log(this.transform.name);
            float v = (Flotteur.position.y - value ) * 20;
            RB.AddForce(new Vector3(-FlooterPoint.x * v, -FlooterPoint.y * v, -FlooterPoint.z * v));
        }
    }


  
}
