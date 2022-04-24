using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailControlleurScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour :Gérer la voile
    /// </summary>

    [Header("Conpenents")] 
    public InputBoatScript IBS;

    public Transform Bateau;
    public Transform SAIL;

    [Header("Values")]
    public float RotateSpeed;


    private float Angle;
    private Quaternion oldRotate;



    public Vector3 AxeSail()
    {
        var position = SAIL.forward;
        return new Vector3(position.x,0, position.z); // A CHANGER CA AUSSI;

    }
    
    // Start is called before the first frame update
    void Start()
    {
        oldRotate = SAIL.transform.rotation;
    }

    float calculangle()
    {
       
        
        var position = SAIL.forward; // CHANGER L AXE PLUS TARD 
        var position1 = Bateau.forward;
        float  Angle = Vector2.Angle(new Vector2(position.x,position.z),new Vector2(position1.x,position1.z));
        
        return Angle;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(this.transform.position, SAIL.transform.parent.up * 500);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        Angle = calculangle();
        
        if (Angle <= 90)
        { 
            oldRotate = SAIL.transform.rotation;
        }
        
        if ( IBS.isSailTurningRight() > 0)
        {
            SAIL.transform.RotateAround(SAIL.transform.position,SAIL.transform.up,-RotateSpeed * Time.fixedDeltaTime * IBS.isSailTurningRight());

            

        }
        
   
        
        if ( IBS.isSailTurningLeft() > 0)
        {
            SAIL.transform.RotateAround(SAIL.transform.position,SAIL.transform.up,RotateSpeed * Time.fixedDeltaTime );
        
        }

      
        
        Angle = calculangle();

        if (Angle > 90)
        {
            SAIL.transform.rotation = oldRotate;
        }
        

    }
    
}
