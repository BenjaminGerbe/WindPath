using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class SocialNetworkj : MonoBehaviour
{

    public TextMeshProUGUI Dashboard;
    
    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "fr";
    public static string descriptionParam;

    
    
    
    public void ShareToTW(string linkParameter)
    {

    
        Application.OpenURL(TWITTER_ADDRESS +
                            "?text=" + UnityWebRequest.EscapeURL("Regardez le score que j'ai fais sur WindPath \n"+Dashboard.text));
        
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
