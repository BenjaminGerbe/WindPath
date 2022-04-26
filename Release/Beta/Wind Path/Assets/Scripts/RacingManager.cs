using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class RacingManager : MonoBehaviour
{

    /// <summary>
    /// Script fait par : Benjamin et Julien
    /// Utilisé pour : Gérer la course
    /// </summary>
    ///

    [Header("Conpenents")] 
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI Counter;

    public WindControl WC;
    private float RaceTime;
    private float StartTime = 0;
    private int Timer = 4;
    private float counterTimer = 0;
    private bool hideCounter = false;
    private string RealTime;
    
    private BoatControlleurScript[] lstBCS;
    private float _windStrength = 0;

    private bool start = false;


    public string getTime()
    {
        return this.RealTime;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
        counterTimer = Timer;

        lstBCS = GameObject.FindObjectsOfType<BoatControlleurScript>();

        foreach (var boat  in lstBCS)
        {
            boat.enabled = false;
        }

        _windStrength = WC.windStrength;
        WC.windStrength = 0;

    }
    
    
    
    void SetStart()
    {
        WC.windStrength = _windStrength;
        
        foreach (var boat  in lstBCS)
        {
            boat.enabled = true;
        }
    }
    
    // Update is called once per frame
    void Update()
    {

        if (!hideCounter)
        {
            counterTimer -= Time.deltaTime;
            Counter.text = ((int)(counterTimer)).ToString();

            if (counterTimer < 1)
            {
                Counter.text = "GO !";
                SetStart();
                start = true;
                
            }

            if (counterTimer < 0)
            {
                Counter.transform.parent.gameObject.SetActive(false);
                hideCounter = true;
            }
         
            
        }
        
     
        
        if (start)
        {
            RaceTime = Time.time - StartTime;
            TimeSpan t = TimeSpan.FromSeconds(RaceTime);
            RealTime =  t.ToString(@"mm\:ss\:fff");

            TimerText.text = RealTime;
        }

    }
}
