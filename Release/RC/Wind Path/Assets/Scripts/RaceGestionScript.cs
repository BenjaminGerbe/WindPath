using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public  struct Racer
{
    public string racer;

    public int score;

    public void setScore(int i)
    {
        score = i;
    }
    
}

public class RaceGestionScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par: Julien
    /// Utilisé pour : classement joueurs
    /// </summary>

    public TextMeshProUGUI leader;
    public  GameObject leaderboardscreen;
    private Collider[] checkpoint;
    
    public static bool reset = true;
    public int nbOfBoat =  6;
    public Transform allBoats;
    
     public static List<GameObject> racers;

    private float countRacer = 0;
    private bool raceFinished = false;
    
    [SerializeField]
    public static List<Racer> leaderboard;
    private GUIStyle Style = new GUIStyle();
    // Start is called before the first frame update
    void Start()
    {

        racers = new List<GameObject>();
        
        foreach (Transform Tr in allBoats)
        {
            racers.Add(Tr.gameObject);
        }
        
    
        countRacer = 0;
        GameObject[] rac= GameObject.FindGameObjectsWithTag("Boat");
        racers = new List<GameObject>(rac);
        if (PlayerPrefs.HasKey("GameType") && PlayerPrefs.GetString("GameType") == "Solo")
        {
            racers.Remove(GameObject.Find("Player2"));
        }
        else
        {
            racers.Remove(GameObject.Find("IA 5"));
        }

        if (leaderboard == null || ( leaderboard != null &&  reset ) )
        {
            reset = false;
            leaderboard = new List<Racer>();
            foreach (GameObject GO  in racers)
            {
                Racer r = new Racer();
                r.racer = GO.name;
                leaderboard.Add(r);
            }

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
        }
    }

    void OnGUI()
    {
        
    }

    int findRacer(GameObject racer)
    {
        int i = 0;
        bool trouver = false;

        while (i < leaderboard.Count && !trouver)
        {

            if (racer.name == leaderboard[i].racer)
            {
                trouver = true;
            }
            else
            {
                i++;
            }
        }

        if (!trouver)
        {
            return -1;
        }
        
        
        return i;
    }

    bool finishRace()
    {
        Debug.Log(countRacer +">="+ nbOfBoat);
       if(countRacer >= nbOfBoat) return true;

       return false;
    }

    public void setFinish(GameObject racer)
    {
     
    

        int i =  findRacer(racer);
       
        if (i >= 0 && i < leaderboard.Count)
        {
        
            var racer1 = leaderboard[i];
            racer1.score += racers.Count - ((int)countRacer );
            
            leaderboard[i] = racer1;
            
            leader.text += countRacer + 1 + " : " + racer.name+" score :" + leaderboard[i].score.ToString() +  "\n";
            countRacer++;
        }
        
    
    }
}
