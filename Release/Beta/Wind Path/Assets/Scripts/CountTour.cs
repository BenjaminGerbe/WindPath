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
    private bool[] allCheck = null;
    private bool finish = false;
    private GameObject lb;
    private RaceGestionScript rcs;

    public int nbTour;
    public Collider[] Checkpoint;
    private int lastCheckPoint;
    public bool isFinish()
    {
        return finish;
    }

    public string getTime()
    {
        return this.RealRaceTime;
    }
    
    public int getLastCheckpointpassed()
    {
        return lastCheckPoint;
    }
    
    void Start()
    {
        lb = GameObject.Find("Racing Setup");
        rcs = lb.GetComponent<RaceGestionScript>();
        GameObject Checkpoints = GameObject.Find("Checkpoints");
        nbTour = Checkpoints.GetComponent<Checkpoints>().nbTour;
        Checkpoint = Checkpoints.GetComponent<Checkpoints>().Checkpoint;

        allCheck = new bool[Checkpoint.Length];
      
        for (int i = 0; i < allCheck.Length;i++)
        {
            
            allCheck[i] = true;
        }
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("finish line") && allTrue())
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
                rcs.setFinish(this.gameObject);
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
                    lastCheckPoint = i;
                    break;
                }
            }
            
            if (i >= 0 && i < Checkpoint.Length)
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

    public bool isFinish()
    {
        return finish;
    }

    public string getTime()
    {
        return this.RealRaceTime;
    }

    public int getLastCheckpointpassed()
    {
        int i = 0;
        if (allCheck != null)
        {
            while (i < this.allCheck.Length && this.allCheck[i] == true)
            {
                i++;
            }
        }
        i--;
        return i;
    }

    public int getTour()
    {
        return this.ActualTour;
    }

    public float getCurrentTour()
    {

        return ActualTour;
    }
}
