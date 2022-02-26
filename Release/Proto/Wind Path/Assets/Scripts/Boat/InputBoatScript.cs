using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class InputBoatScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Génrer les input
    /// </summary>


    private bool RT = false;
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
    
    public virtual bool sailIsRight()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 )  return  true;
        return false;
    }
    
    public virtual bool sailIsLeft()
    {
   
        if (Input.GetAxisRaw("Horizontal") < 0 )  return  true;
        
     
        return false;
    }
    
    

    public virtual bool isRT()
    {
        if (Input.GetAxisRaw("Sail") > 0)
        {
        
            Debug.Log("yo");
            RT = true;
            return true;
        }

        RT = false;
        return false;
    }
    

}
