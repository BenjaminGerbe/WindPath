using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Random = System.Random;

[RequireComponent(typeof(BoatControlleurScript))]
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Permet de gérer le changement de camera
    /// </summary>
    ///     
    
    [Header("Camera")] 
    public GameObject CameraInterior;
    public GameObject Sail;
    
    
    [HideInInspector]
    public Camera Camera;
    
    [HideInInspector]
    public GameObject CameraBack;
    
    [HideInInspector]
    public CinemachineBrain CB;

    [HideInInspector]
    public LayerMask LMBasic; 
    [HideInInspector]
    public LayerMask LMInterior;

    
    [HideInInspector]
    public LayerMask LMSAIL;
    
    
    private BoatControlleurScript BCS;
    private InputClass IC;

    private Camera camInter;
    private bool BackCamera = false;
    private bool InterCamera = false;
    
    
    public static int getIndexOfLayer(LayerMask layerMask) {
        
        int layerNumber = 0;
        int layer = layerMask.value;
        
        while(layer > 0) {
            
            layer = layer >> 1;
            layerNumber++;
            
        }
        
        return layerNumber - 1;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        BCS = GetComponent<BoatControlleurScript>();
        IC = BCS.IBS;


        camInter = CameraInterior.transform.GetChild(0).GetComponent<Camera>();
        camInter.enabled = false;
        
        
        Sail.layer = getIndexOfLayer(LMSAIL);


    }


    private void Update()
    {
    
        if (IC.BackCamera())
        {

            BackCamera = true;
        }
        
        if (IC.InteriorCamera())
        {
            InterCamera = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Camera.cullingMask = LMBasic;
        
        camInter.enabled = false;
        
        if (InterCamera)
        {
         
            InterCamera = false;
            CameraInterior.SetActive(!CameraInterior.activeSelf);
            
        }

        if (CameraInterior.activeSelf && !CB.IsBlending)
        {
            Camera.cullingMask = LMInterior;
            camInter.enabled = true;
           
        }
        
        
   
        if (CameraBack) 
        {
            CameraBack.SetActive(false);
            if (BackCamera)
            {
                BackCamera = false;
                Camera.cullingMask = LMBasic;
                CameraBack.SetActive(true);
            }
        }

    }
}
