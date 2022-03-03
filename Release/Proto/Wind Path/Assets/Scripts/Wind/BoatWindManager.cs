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


    void Start()
    {

        if (windControl is null)
        {
            windControl = FindObjectOfType<WindControl>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
     

        float angle = Vector3.Angle(SailTransform.AxeSail() , windControl.GetVectorWind());
        
        float val = angle / 180f;
        float speed = Mathf.Lerp(1f,0,val);
        
        Vector3 windVector = (SailTransform.AxeSail().normalized  + windControl.GetVectorWind().normalized).normalized;
      
        rigidbodyBoat.AddForce(  windVector*coeffWind * speed * windControl.windStrength,ForceMode.Acceleration) ;
        
        

    }
}
