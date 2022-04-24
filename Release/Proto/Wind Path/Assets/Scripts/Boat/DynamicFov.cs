using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DynamicFov : MonoBehaviour
{

    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Ce script permet de changer le fov selon la vitesse du bateau
    /// </summary>
    ///
    [Header("Components")] 
    public CinemachineVirtualCamera CVC;
    public Rigidbody RB;

    [Header("Values")] 
    public float fovMin = 70;
    public float fovMax = 90;
    public float minVitesse = 20;
    public float maxVitese = 35;
    public float speedTransition = 1;

    private float fov;
    private float currentFov;

    // Start is called before the first frame update
    void Start()
    {
        fov = fovMin;
        currentFov = fov;
     
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(transform.InverseTransformDirection(RB.velocity).z);
        
        float pourcentage = Mathf.InverseLerp(minVitesse, maxVitese,
            Mathf.Abs(transform.InverseTransformDirection(RB.velocity).z));
        fov = Mathf.Lerp(fovMin, fovMax, pourcentage);

        if (fov > currentFov)
        { 
            currentFov += Time.fixedDeltaTime * speedTransition;
          
        }
        else  if (fov < currentFov)
        {
         
            currentFov -=  Time.fixedDeltaTime * speedTransition;
        }
     
        currentFov = Mathf.Clamp(currentFov,fovMin, fovMax);

        CVC.m_Lens.FieldOfView = currentFov;
        
        
     
    }
}
