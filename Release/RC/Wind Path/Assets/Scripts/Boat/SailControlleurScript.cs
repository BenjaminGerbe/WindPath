using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


[RequireComponent(typeof(BoatControlleurScript))]
public class SailControlleurScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour :Gérer la voile
    /// </summary>

    [Header("Conpenents")]
    
    public Transform SAIL;
    
    private InputClass IBS;
    private Transform Bateau;
    [Header("Values")]
    public float RotateSpeed;


    private float Angle;
    private Quaternion oldRotate;



    public Vector3 AxeSail()
    {
        var position = SAIL.forward;
        return -SAIL.right; // A CHANGER CA AUSSI;

    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        BoatControlleurScript BCS = GetComponent<BoatControlleurScript>();
        IBS = BCS.IBS;
        Bateau = BCS.Boat;
        oldRotate = SAIL.transform.rotation;
    }

    public float calculangle()
    {

        var position = Vector3.ProjectOnPlane( -SAIL.right,Bateau.up).normalized; // CHANGER L AXE PLUS TARD 
        var position1 = Vector3.ProjectOnPlane( Bateau.forward , Bateau.up).normalized;


  
   
        float  Angle = Vector2.Angle(new Vector2(position.x,position.z),new Vector2(position1.x,position1.z));
        
        return Angle;
    }


    private void Update()
    {
        var localEulerAngles = SAIL.localEulerAngles;
        SAIL.transform.localRotation = Quaternion.Euler(-90,localEulerAngles.y,localEulerAngles.z);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
      
         
        
        Angle = calculangle();
        
        if (Angle <= 90)
        { 
            oldRotate = SAIL.transform.rotation;
        }
        
        if ( IBS.isSailTurningRight() > 0 && Angle <= 90)
        {
            Quaternion basicRoation = Bateau.transform.rotation;
            Bateau.transform.rotation = Quaternion.identity;
            
            
           
            SAIL.transform.RotateAround(Bateau.transform.position,SAIL.transform.forward,-RotateSpeed * Time.fixedDeltaTime * IBS.isSailTurningRight());
            
            Bateau.transform.rotation = basicRoation;

        }
    
        if ( IBS.isSailTurningLeft() > 0 &&  Angle <= 90)
        {
            Quaternion basicRoation = Bateau.transform.rotation;
            Bateau.transform.rotation = Quaternion.identity;
            
           
            
            SAIL.transform.RotateAround(Bateau.transform.position,SAIL.transform.forward,RotateSpeed * Time.fixedDeltaTime  * IBS.isSailTurningLeft());
            
            Bateau.transform.rotation = basicRoation;
        }
    
        

        
        Angle = calculangle();

        if (Angle > 90)
        {
      
        
            SAIL.transform.rotation = oldRotate;
        }
        
    }
    
}
