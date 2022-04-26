using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputClass : MonoBehaviour
{


    public virtual bool isTurningRight()
    {
        return false;
    }
    
    public virtual bool isTurningLeft()
    {
        return false;
    }
    
    public virtual bool isAccelerate()
    {
        return false;
    }
    

    public virtual float isSailTurningRight()
    {
        return 0;
    }
    
    public virtual float isSailTurningLeft()
    {
        return 0;
    }
}
