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
    private bool finish = false;
    
    public int nbTour;
    public Collider[] Checkpoint;

    public bool isFinish()
    {
        return finish;
    }

    public string getTime()
    {
        return this.RealRaceTime;
    }
    

    
    public int getTour()
    {
        return this.ActualTour;
    }
    
    public float getCurrentTour()
    {
      
        return ActualTour;
    }
    
    void Start()
    {

        allCheck = new bool[Checkpoint.Length];
      
        for (int i = 0; i < allCheck.Length;i++)
        {
            
            allCheck[i] = true;
        }
    }

    // Update is called once per frame

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
            if (ActualTour > nbTour && !finish)
            {
                finish = true;
                if (GetComponent<InputBoatScript>())
                {
                    Debug.Log("finish");
                    GetComponent<InputBoatScript>().enabled = false;
                    IABoatScript IBS = this.gameObject.AddComponent<IABoatScript>();
                    IBS.WC = GameObject.FindObjectOfType<WindControl>();
                    IBS.MIS = GameObject.FindObjectOfType<MilesStoneIAScript>();
                    BoatControlleurScript BS = GetComponent<BoatControlleurScript>();
                    BS.IBS = IBS;
                }
                

            }
        }
        else if (other.CompareTag("Checkpoint"))
        {
            int i;
    
            for (i = 0; i < Checkpoint.Length; i++)
            {
                
                if (other.name == Checkpoint[i].name)
                {
                    break;
                }
            }
            if (i >= 0 && i < checkpoint.Length)
            {
                
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
       // GUI.Label(new Rect(Screen.width / 20 - 60, Screen.height / 810, 400, 80), tour+"\n"+RealRaceTime,Style);
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
