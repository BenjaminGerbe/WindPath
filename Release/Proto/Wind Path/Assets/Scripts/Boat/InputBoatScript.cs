using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class InputBoatScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Génrer les input
    /// </summary>
    
    public virtual bool isTurningRight()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 )  return  true;
        return false;
    }
    
    public virtual bool isTurningLeft()
    {
   
        if (Input.GetAxisRaw("Horizontal") < 0  )  return  true;
        
     
        return false;
    }
    
    public virtual bool isAccelerate()
    {
        if (Input.GetAxisRaw("Vertical") > 0 )  return  true;
        return false;
    }
    

    public virtual float isSailTurningRight()
    {

        if (Input.GetAxisRaw("TurnSailRight") > 0 )  return  Input.GetAxis("TurnSailRight");
        
        return  Input.GetButton("TurnSailRight") == true ? 1 : 0 ;
    }
    
    public virtual float isSailTurningLeft()
    {
        if (Input.GetAxisRaw("TurnSailLeft") > 0 )  return  Input.GetAxis("TurnSailLeft");
        
        return  Input.GetButton("TurnSailLeft") == true ? 1 : 0 ;
    }
    

}
