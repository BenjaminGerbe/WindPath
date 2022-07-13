using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoatControlleurScript))]
public class SailControlleurScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour :Gérer la voile
    /// </summary>

    [Header("Conpenents")]
    
    public Transform SAIL;
    
    private InputClass IBS;
    private Transform Bateau;
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
        BoatControlleurScript BCS = GetComponent<BoatControlleurScript>();
        IBS = BCS.IBS;
        Bateau = BCS.Boat;
        oldRotate = SAIL.transform.rotation;
    }

    public float calculangle()
    {
        
        var position = SAIL.forward; // CHANGER L AXE PLUS TARD 
        var position1 = Bateau.forward;
        float  Angle = Vector2.Angle(new Vector2(position.x,position.z),new Vector2(position1.x,position1.z));
        
        return Angle;
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
            Quaternion basicRoation = Bateau.transform.rotation;
            Bateau.transform.rotation = Quaternion.identity;
            SAIL.transform.RotateAround(SAIL.transform.position,SAIL.transform.up,-RotateSpeed * Time.fixedDeltaTime * IBS.isSailTurningRight());

            Bateau.transform.rotation = basicRoation;

        }
        
        
        if ( IBS.isSailTurningLeft() > 0)
        {
            Quaternion basicRoation = Bateau.transform.rotation;
            Bateau.transform.rotation = Quaternion.identity;
            SAIL.transform.RotateAround(SAIL.transform.position,SAIL.transform.up,RotateSpeed * Time.fixedDeltaTime );
            Bateau.transform.rotation = basicRoation;
        }

        
        Angle = calculangle();

        if (Angle > 90)
        {
            SAIL.transform.rotation = oldRotate;
        }
        
    }
    
}
