using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


[RequireComponent(typeof(BoatControlleurScript))]
public class AudioBoatManager : MonoBehaviour
{
    
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Gérer le son du bateau
    /// </summary>
    /// 
    
    
    
    public AudioSource Acceleration;
    public AudioSource Sail;
    public AudioSource Cannon;

    private bool shot = false;
    private float countTour = 0;
    private InputClass IBS;
    private BoatControlleurScript BCS;
    
    // Start is called before the first frame update
    void Start()
    {
        BCS = GetComponent<BoatControlleurScript>();
        IBS = GetComponent<BoatControlleurScript>().IBS;
    }
    


    // Update is called once per frame
    void Update()
    {
        
        if (IBS.isAccelerate())
        {
            Acceleration.enabled = true;
            countTour += 0.5f * Time.deltaTime;
        }
        else
        {
            countTour -= 1f  * Time.deltaTime;
        }

        if (BCS.isStuck() && Cannon != null && !Cannon.isPlaying && !shot)
        {
            Cannon.Play();
            shot = true;


        }
        else if (!BCS.isStuck())
        {
            shot = false;
        }
        
        if ( (IBS.isSailTurningLeft() > 0 || IBS.isSailTurningRight() > 0) && !Sail.isPlaying )
        {
           
            Sail.Play();
            Sail.pitch = Random.Range(1f, 1.2f);
        }
        
        
        countTour = Mathf.Clamp(countTour, 0, 1);
        
        Acceleration.pitch = Mathf.Lerp(1, 2,countTour);
        
    }
}
