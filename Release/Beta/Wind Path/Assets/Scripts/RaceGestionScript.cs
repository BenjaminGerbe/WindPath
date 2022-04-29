using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaceGestionScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par: Julien
    /// Utilisé pour : classement joueurs
    /// </summary>

    public TextMeshProUGUI leader;
    public GameObject leaderboardscreen;
    private Collider[] checkpoint;
    
    [SerializeField]
    private List<GameObject> racers;
    
    private bool[] finish;
    private bool raceFinished = false;
    [SerializeField]
    private List<GameObject> leaderboard = new List<GameObject>();
    private GUIStyle Style = new GUIStyle();
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] rac= GameObject.FindGameObjectsWithTag("Boat");
        racers = new List<GameObject>(rac);
        if (PlayerPrefs.HasKey("GameType") && PlayerPrefs.GetString("GameType") == "Solo")
        {
            racers.Remove(GameObject.Find("BP-1(player 2)"));
        }
        else
        {
            racers.Remove(GameObject.Find("Boat-IA (IA 5)"));
        }
        finish = new bool[racers.Count];
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
        if (raceFinished)
        {
            GameObject.Find("EventSystem").GetComponent<PauseMenu>().enabled = false;
            leaderboardscreen.SetActive(true);
            GameObject.Find("Return").GetComponent<UnityEngine.UI.Button>().Select();
            string sld = "";
            for (int i = 0; i < leaderboard.Count; i++)
            {
                sld+=i + 1 + " : " + leaderboard[i].name+"\n";
            }
            leader.text = sld;
        }
    }

    void OnGUI()
    {
        
    }

    bool finishRace()
    {
       if(leaderboard.Count==6)
        {
            return true;
        }
       else
        {
            return false;
        }
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
