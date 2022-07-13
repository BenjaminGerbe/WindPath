using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SailControlleurScript))]
public class BoatWindManager : MonoBehaviour
{
    /// <summary>
    /// Script fait par SONTOT Alexis 
    /// Utilisé pour : Contrôler l'interaction vent/bateau
    /// </summary>
    // Start is called before the first frame update

    [Header("Components")]
    public WindControl windControl;
 
  
    private Rigidbody rigidbodyBoat;
    private SailControlleurScript sailControlleur;
    [Header("Values")]
    [Range(0f,1f)]
    public float coeffWind =1;

    public AnimationCurve WindInpact;
    
    private Vector3 directionSail;

    private Vector3 boatDirection;
    private float speed;
    void Start()
    {
        rigidbodyBoat = GetComponent<Rigidbody>();
        sailControlleur = GetComponent<SailControlleurScript>();
        if (windControl is null)
        {
            windControl = FindObjectOfType<WindControl>();
        }
    }

    public Vector3 getDirectionBoat()
    {
        return boatDirection;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        
         

        float angle = Vector3.Angle(sailControlleur.AxeSail() , windControl.GetVectorWind());

     
        float val = angle / 180f; 
        speed = WindInpact.Evaluate(val);
        
        
        boatDirection = (sailControlleur.AxeSail().normalized + windControl.GetVectorWind().normalized).normalized;
      
        rigidbodyBoat.AddForce(  boatDirection*speed* (windControl.windStrength*coeffWind) ,ForceMode.Acceleration) ;
        
        

    }
}
