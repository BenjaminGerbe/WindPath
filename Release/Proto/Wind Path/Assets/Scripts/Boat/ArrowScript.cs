using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class ArrowScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par: Benjamin
    /// Utilisé pour : Ce script permet à la fleche de suivre la direction du vent
    /// </summary>
    [Header("Conpenents")]
    public MonoBehaviour MBControler;
    public Transform AlignItem;

    private WindControl _controlerWC;
    

    // Update is called once per frame
    void Update()
    {
        if (MBControler is WindControl)
        {
            aligne(MBControler as WindControl);
        }
        else if (MBControler is SailControlleurScript)
        {
            aligne(MBControler as SailControlleurScript);
        }
        else if (MBControler is BoatWindManager)
        {
            aligne(MBControler as BoatWindManager);
        }
        else
        {
            aligne(MBControler);
        }
   
        
    }

  
    public void aligne<T>(T item)
    {
        Debug.LogError("ArrowScript ne peux aligner qu'avec le script windControler et SailControlleurScript");
    }

    public void aligne(WindControl item)
    {
     
        AlignItem.rotation = Quaternion.LookRotation(item.GetVectorWind());
    }
    
    public void aligne(BoatWindManager item)
    {
     
        AlignItem.rotation = Quaternion.LookRotation(item.getDirectionBoat());
    }
    
    public void aligne(SailControlleurScript item)
    {
      
        SailControlleurScript V = MBControler as SailControlleurScript;
    
        
        AlignItem.rotation = Quaternion.LookRotation(V.AxeSail());
    }

    
}
