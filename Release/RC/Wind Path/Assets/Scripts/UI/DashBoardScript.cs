using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DashBoardScript : MonoBehaviour
{

    public TextMeshProUGUI TMPGUI;
    // Start is called before the first frame update
    void Start()
    {

        if (RaceGestionScript.leaderboard != null)
        {
            int i = 0;

            RaceGestionScript.leaderboard = RaceGestionScript.leaderboard.OrderByDescending(x => x.score).ToList();
            foreach (Racer Rcr in RaceGestionScript.leaderboard )
            {
                
                TMPGUI.text += i + 1 + " : " + Rcr.racer +" score :" + Rcr.score.ToString() +  "\n";
                i++;
            }

            RaceGestionScript.reset = true;

        }
        
        
             
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
