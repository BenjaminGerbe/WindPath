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
    [Header("Components")] 
    public Transform Boat;
    public Transform modelBoat;
    
    public Rigidbody RB;
    public InputBoatScript IBS;
    
    [Header("Values")] 
    public float moveSpeed;
    public float torqueSpeed;
    public float MaxVitesse;
    public float MaxRotationVitesse;

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
            
        if (IBS.isTurningRight())
        {
            IsTurningRight = true;
        }
        
        if (IBS.isTurningLeft())
        {
          
            IsTurningLeft = true;
        }
        
        if (IBS.isAccelerate())
        {
             isAccelerate= true;
        }
    }

   
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAccelerate)
        {
            RB.velocity += Boat.transform.forward * moveSpeed;
        }
        if (IsTurningLeft && Mathf.Abs(transform.InverseTransformDirection(RB.velocity).z) > 0 )
        {
            RB.AddTorque(Boat.transform.up * -torqueSpeed, ForceMode.Acceleration);
        }
        if (IsTurningRight  && Mathf.Abs(transform.InverseTransformDirection(RB.velocity).z) > 0 )
        {
            RB.AddTorque(Boat.transform.up * torqueSpeed, ForceMode.Acceleration);
        }

        int signed = 1;
        if (RB.angularVelocity.y < 0)
        {
            signed = -1;
        }
        
        RB.velocity = Vector3.ClampMagnitude(RB.velocity, MaxVitesse);
  

        
        PourcentageRotation = Mathf.Clamp01(   Mathf.Abs(RB.angularVelocity.y));
        
        Boat.transform.rotation = Quaternion.Euler( 0, Boat.transform.eulerAngles.y,  Rotation * RotationAnimaiton.Evaluate(PourcentageRotation) *signed   );
        
        
    }
}
