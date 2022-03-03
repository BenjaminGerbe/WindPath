using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BoatWindManager : MonoBehaviour
{
    /// <summary>
    /// Script fait par SONTOT Alexis 
    /// Utilisé pour : Contrôler l'interaction vent/bateau
    /// </summary>
    // Start is called before the first frame update

    [Header("Components")]
    public WindControl windControl;
    public Rigidbody rigidbodyBoat;
    public SailControlleurScript SailTransform;
    public BoatControlleurScript BCS;
    
    [Header("Values")]
    [Range(0f,1f)]
    public float coeffWind =1;

    public AnimationCurve WindInpact;

    public Transform deffuger;
    private Vector3 directionSail;

    private Vector3 boatDirection;
    private float speed;
    void Start()
    {

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
        
     

        float angle = Vector3.Angle(SailTransform.AxeSail() , windControl.GetVectorWind());

     
        float val = angle / 180f; 
        speed = WindInpact.Evaluate(val);
        
        
        boatDirection = (SailTransform.AxeSail().normalized + windControl.GetVectorWind().normalized).normalized;
      
        rigidbodyBoat.AddForce(  boatDirection*coeffWind*speed* windControl.windStrength,ForceMode.Acceleration) ;
        
        

    }
}
