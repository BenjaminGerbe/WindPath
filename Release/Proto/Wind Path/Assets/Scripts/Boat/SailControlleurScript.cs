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
    
    // Update is called once per frame
    void Update()
    {
     

        Angle = calculangle();
        
        if (Angle <= 90)
        { 
            oldRotate = SAIL.transform.rotation;
        }
        
      
        
        if (IBS.isRT() )
        {
            if (IBS.sailIsLeft())
            {
                SAIL.transform.Rotate(Vector3.up,-RotateSpeed);
                
            }
            
            if (IBS.sailIsRight())
            {
                SAIL.transform.Rotate(Vector3.up,RotateSpeed);
            }
            
        }
        
        Angle = calculangle();
        
        
        if (Angle > 90)
        {
            SAIL.transform.rotation = oldRotate;
        }

    




    }
    
    void FixedUpdate()
    {
        
    }
}
