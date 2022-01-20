using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountTour : MonoBehaviour
{
    /// <summary>
    /// Script fait par: Julien
    /// Utilisé pour : Passage des tours de circuit et temps de parcours global (UI intégré)
    /// </summary>

    private float RaceTime;
    private string RealRaceTime;
    private float StartTime = 0;
    private int ActualTour = 0;
    private bool check = true;
    public int nbTour;


    // Update is called once per frame
    void Update()
    {
        if (StartTime != 0 && ActualTour <= nbTour)
        {
            RaceTime = Time.time - StartTime;
            TimeSpan t = TimeSpan.FromSeconds(RaceTime);
            RealRaceTime = t.ToString(@"mm\:ss\:fff");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="finish line" && check == true)
        {
            check = false;
            ActualTour++;
            if (ActualTour == 1)
            {
                StartTime = Time.time;
            } 
            if (ActualTour > nbTour)
            {
                
            }
        }
        if (other.name=="checkpoint")
        {
            check = true;
        }
    }

    void OnGUI()
    {
        string tour = "";
        if (ActualTour > nbTour)
        {
            tour = "finish";
        }
        else
        {
            tour = ActualTour.ToString();
        }
        GUI.Label(new Rect(300, 100, 400, 80), tour+"\n"+RealRaceTime);
    }
}
