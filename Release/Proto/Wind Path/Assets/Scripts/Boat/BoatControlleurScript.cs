using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControlleurScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Déplacer le bateau
    /// </summary>
    /// 
    [Header("Conpenents")] 
    public Transform Boat;

    public Rigidbody RB;

    [Header("Values")] 
    public float moveSpeed;
    public float torqueSpeed;

    [Header("Animation")] 
    public AnimationCurve RotationAnimaiton; //  Rotation selon la vitesse de la rotation

    public float Rotation;
    
    
    private bool isAccelerate;
    private bool IsTurningLeft;
    private bool IsTurningRight;

    private float PourcentageRotation;
    
    // Start is called before the first frame update
    void Start()
    {
      
        
    }


    private void Update()
    {
        isAccelerate = false;
        IsTurningLeft = false;
        IsTurningRight = false;
            
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            isAccelerate = true;
        }
        
        
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            IsTurningLeft = true;
        }
        
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            IsTurningRight = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAccelerate)
        {
            RB.velocity += Boat.transform.forward * moveSpeed;
        }
        if (IsTurningLeft && transform.InverseTransformDirection(RB.velocity).z > 0 )
        {
            RB.AddTorque(Boat.transform.up * -torqueSpeed, ForceMode.Acceleration);
        }
        if (IsTurningRight  && transform.InverseTransformDirection(RB.velocity).z > 0 )
        {
            RB.AddTorque(Boat.transform.up * torqueSpeed, ForceMode.Acceleration);
        }

        int signed = 1;
        if (RB.angularVelocity.y < 0)
        {
            signed = -1;
        }
        
        
       
        
        PourcentageRotation = Mathf.Clamp01(   Mathf.Abs(RB.angularVelocity.y));
        
        Boat.transform.rotation = Quaternion.Euler( 0, Boat.transform.eulerAngles.y,  Rotation * RotationAnimaiton.Evaluate(PourcentageRotation) *signed   );
        
        
    }
}
