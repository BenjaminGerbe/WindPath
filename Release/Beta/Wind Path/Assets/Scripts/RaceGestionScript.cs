using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceGestionScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par: Julien
    /// Utilisé pour : tours de tous les joueurs + classement
    /// </summary>
    public int nbTour;
    public Collider[] checkpoint;
    public GameObject[] racers;
    private bool[] finish;
    private bool raceFinished = false;
    private List<GameObject> leaderboard = new List<GameObject>();
    private GUIStyle Style = new GUIStyle();
    // Start is called before the first frame update
    void Start()
    {
        finish = new bool[racers.Length];
        for (int i = 0; i < finish.Length;i++)
        {
            finish[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (finishRace()) {
            raceFinished = true;
        }
    }

    void OnGUI()
    {
        if (raceFinished)
        {
            Style.fontSize = 25;
            for (int i = 0; i < leaderboard.Count;i++)
            {
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 8+i*10, 400, 80), i+1 + " : "+ leaderboard[i].name, Style);
            }
        }
    }

    bool finishRace()
    {
        bool fin = true;
        for (int i = 0;i < finish.Length;i++)
        {
            if (finish[i]==false)
            {
                fin = false;
            }
        }
        return fin;
    }

    public void setFinish(GameObject racer)
    {
        int i = 0;
        while(racers[i].name != racer.name)
        {
            i++;
        }
        finish[i] = true;
        leaderboard.Add(racers[i]);
    }
}
