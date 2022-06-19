using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBonusHolder : MonoBehaviour,BonusObject
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Permet de gérer le bonus de vent
    /// </summary>

    public string NameOfBonus;
    private WindControl WC;


    
    private void Start()
    {
        WC = GameObject.FindObjectOfType<WindControl>();
    }

    public void LoadEffect(Transform go)
    {
        
    }


    public string getName()
    {
        return NameOfBonus;
    }

    public void Starteffect(Transform go)
    {
        this.WC.ForceSetWind(new Vector3(go.forward.x,go.forward.z));
    }
}
