using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class IABoatScript : InputClass
{
    /// <summary>
    /// Script fait par: Benjamin
    /// Utilisé pour : gérer les ia des bateaux
    /// </summary>

    [Header("Compenent")]
    public MilesStoneIAScript MIS;
    public WindControl WC;
    
    private NavMeshPath NMP;
    private Rigidbody RB;
    private Vector3 direction;
    private int currentTargetPoint;
    private void Start()
    {
        NMP = new NavMeshPath();
        RB = GetComponent<Rigidbody>();
        calculateDirection();
    }


    public void calculateDirection()
    {
        if (NMP.corners.Length <= 0)
        {
           
            return;
        }
        
        direction = Vector3.ProjectOnPlane(this.NMP.corners[1] - this.transform.position,Vector3.up);
        direction = direction.normalized;
    }
    
    private void Update()
    {
       // _navMeshAgent.SetDestination(targetPoint.position);
     
        Vector3 currentTarget = MIS.positionMilesStones[this.currentTargetPoint].position;
        if (Vector3.Distance(currentTarget,this.transform.position) < MIS.distanceChange)
        {

           currentTargetPoint += 1;
           currentTargetPoint = currentTargetPoint % MIS.positionMilesStones.Count;
        }
        

        NavMesh.CalculatePath(transform.position, currentTarget, NavMesh.AllAreas, NMP);
        
        for (int i = 0; i < NMP.corners.Length - 1; i++){
    
           Debug.DrawLine(NMP.corners[i], NMP.corners[i + 1], Color.red);
        }

    }

    public override bool isTurningRight()
    {

       

        calculateDirection();
        Debug.DrawLine(this.transform.position,this.transform.position + this.direction*5,Color.yellow);

        float Angle =  Vector3.SignedAngle(this.transform.forward,direction,Vector3.up);

        if (Angle > 10f)
        {
           return true;
        }

        return false;
    }
    
    public override bool isTurningLeft()
    {
        
        
        Debug.DrawLine(this.transform.position,this.transform.position + direction*5,Color.yellow);
        calculateDirection();
        float Angle =  Vector3.SignedAngle(this.transform.forward,direction,Vector3.up);

        if (Angle < -10f)
        {
            return true;
        }
        return false;
    }
    
    public override bool isAccelerate()
    {
       
  
        Debug.DrawLine(this.transform.position,this.transform.position + direction*5,Color.yellow);
        calculateDirection();
        float Angle =  Vector3.SignedAngle(this.transform.forward,direction,Vector3.up);
        
        
        if ( Mathf.Abs(Angle) > 90 &&  Mathf.Abs(transform.InverseTransformDirection(RB.velocity).z) >= 5f )
        {
            return false;
        }
        
        
        return true;
    }
    

    public override float isSailTurningRight()
    {
        
        calculateDirection();

        float angle = Vector3.SignedAngle(WC.GetVectorWind(),direction,Vector3.up) -  90;

        
        if (angle < 0)
        {
        
            return 1f;
        }
        
        return 0f;
    }
    
    public override float isSailTurningLeft()
    {
        
        calculateDirection();

        float angle = Vector3.SignedAngle(WC.GetVectorWind(),direction,Vector3.up) - 90 ;
        
        
        if (angle > 0)
        {
       
            return 1f;
        }
        
        return 0f;
    }

    
}
