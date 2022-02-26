using System;
using System.Collections;
using System.Collections.Generic;
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
    
    [Header("Values")]
    [Range(0f,1f)]
    public float coeffWind =1;

    public Vector3 LocalVectorForwardSail;

    
    

    private void OnDrawGizmosSelected()
    {
        

    }

    void Start()
    {

        if (windControl is null)
        {
            windControl = FindObjectOfType<WindControl>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
     

        float angle = Vector3.Angle(SailTransform.AxeSail() , windControl.GetVectorWind());
        
        float val = angle / 180f;
        float speed = Mathf.Lerp(1f,0,val);
        
        Debug.Log(speed);
        Vector3 windVector = (SailTransform.AxeSail().normalized  + windControl.GetVectorWind().normalized).normalized;
        
        rigidbodyBoat.velocity += windVector*coeffWind * speed * windControl.windStrength;


    }
}
