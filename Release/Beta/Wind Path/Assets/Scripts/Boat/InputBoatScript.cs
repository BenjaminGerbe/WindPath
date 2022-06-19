using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ControllMethod
{
    Keyboard,
    Controller,
}
public  class InputBoatScript : InputClass, BoatInput.IBateauActions
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Génrer les input
    /// </summary>
    ///
    [SerializeField]
    public BoatInput control;

    public ControllMethod _ControllMethod;
    private void OnEnable()
    {
        if (control == null)
        {
            control = new BoatInput();
            control.Bateau.SetCallbacks(this);
        }
        control.Bateau.Enable();
    }

    public override bool isTurningRight()
    {
        if (_ControllMethod == ControllMethod.Controller)
        {
          
            if (Input.GetAxisRaw("HorizontalC") > 0 )  return  true;
            return false;
        }
        
        if (Input.GetAxisRaw("Horizontal") > 0 )  return  true;
        return false;
    }
    
    public override bool isTurningLeft()
    {
        if (_ControllMethod == ControllMethod.Controller)
        {
            if (Input.GetAxisRaw("HorizontalC") < 0  )  return  true;
        
            return false;
        }
      
        if (Input.GetAxisRaw("Horizontal") < 0  )  return  true;
        
        return false;
    }
    
    public override bool isAccelerate()
    {
        if (_ControllMethod == ControllMethod.Controller)
        {
            
            if (Input.GetAxisRaw("VerticalC") > 0 )  return  true;
   
            return false;
        }
        
        if (Input.GetAxisRaw("Vertical") > 0 )  return  true;
        return false;
    }
    

    public override float isSailTurningRight()
    {
        if (_ControllMethod == ControllMethod.Controller)
        {
            if (Input.GetAxisRaw("TurnSailRightC") > 0 )  return  Input.GetAxis("TurnSailRightC");

            return  Input.GetButton("TurnSailRightC") == true ? 1 : 0 ;
        }

        if (Input.GetAxisRaw("TurnSailRight") > 0 )  return  Input.GetAxis("TurnSailRight");

        return  Input.GetButton("TurnSailRight") == true ? 1 : 0 ;
    }
    
    public override float isSailTurningLeft()
    {
        if (_ControllMethod == ControllMethod.Controller)
        {
            if (Input.GetAxisRaw("TurnSailLeftC") > 0 )  return  Input.GetAxis("TurnSailLeftC");
        
            return  Input.GetButton("TurnSailLeftC") == true ? 1 : 0 ;
        }
        
        if (Input.GetAxisRaw("TurnSailLeft") > 0 )  return  Input.GetAxis("TurnSailLeft");
        
        return  Input.GetButton("TurnSailLeft") == true ? 1 : 0 ;
    }


    public void OnMouvement(InputAction.CallbackContext context)
    {
   
    }
}
