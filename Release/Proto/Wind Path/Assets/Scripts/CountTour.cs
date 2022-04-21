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

    private GUIStyle Style = new GUIStyle();
    private float RaceTime;
    private string RealRaceTime;
    private float StartTime = 0;
    private int ActualTour = 0;
    private bool[] allCheck;
    private int nbTour;
    private Collider[] checkpoint;
    private GameObject Gestion;
    private RaceGestionScript s;

    void Start()
    {
        Gestion = GameObject.Find("RaceGestion");
        s = Gestion.GetComponent<RaceGestionScript>();
        nbTour = s.nbTour;
        checkpoint = s.checkpoint;
        allCheck = new bool[checkpoint.Length];
        for (int i = 0; i < allCheck.Length;i++)
        {
            allCheck[i] = true;
        }
    }

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
        if (other.name == "finish line" && allTrue())
        {
            for (int i = 0; i < allCheck.Length; i++)
            {
                allCheck[i] = false;
            }
            ActualTour++;
            if (ActualTour == 1)
            {
                StartTime = Time.time;
            } 
            if (ActualTour > nbTour)
            {
                s.setFinish(gameObject);
            }
        }
        else
        {
            int i;
            for (i = 0; i < checkpoint.Length; i++)
            {
                if (other.name == checkpoint[i].name)
                {
                    break;
                }
            }
            if (i >= 0 && i < checkpoint.Length)
            {
                Console.WriteLine(i);
                setTrue(i);
            }
           
        }
    }

    void OnGUI()
    {
        string tour = "";
        if (ActualTour > nbTour)
        {
            tour = "FINISH";
        }
        else
        {
            tour = ActualTour.ToString()+"/"+nbTour;
        }
        Style.fontSize = 25;
        GUI.Label(new Rect(Screen.width / 20 - 60, Screen.height / 810, 400, 80), tour+"\n"+RealRaceTime,Style);
    }

    private void setTrue(int i)
    {
        if (i == 0)
        {
            allCheck[i] = true;
        }
        else
        {
            if (allCheck[i-1]==true)
            {
                allCheck[i] = true;
            }
        }
    }

    private bool allTrue()
    {
        for (int i = 0; i < allCheck.Length; i++)
        {
            if (allCheck[i]==false)
            {
                return false;
            }
        }
        return true;
    }
}
