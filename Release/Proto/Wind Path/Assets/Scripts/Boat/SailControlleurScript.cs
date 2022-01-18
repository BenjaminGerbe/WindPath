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

    public Transform SAIL;

    [Header("Values")]
    public float RotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    
    

    // Update is called once per frame
    void Update()
    {
        if (IBS.isRT())
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
    }
    
    void FixedUpdate()
    {
        
    }
}
