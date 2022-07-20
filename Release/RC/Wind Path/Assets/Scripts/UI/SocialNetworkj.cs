using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class SocialNetworkj : MonoBehaviour
{

    public TextMeshProUGUI Dashboard;
    
    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string FB_ADDRESS = "   https://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Flagerbe.itch.io%2Fwindpath%3Fsecret%3DcZyZ37wljk1pxm8vk3i2cTDA&amp%3Bsrc=sdkpreparse";
    private const string TWEET_LANGUAGE = "fr";
    public static string descriptionParam;

    
    
 
    public void ShareToTW()
    {

    
        Application.OpenURL(TWITTER_ADDRESS +
                            "?text=" + UnityWebRequest.EscapeURL("Regardez le score que j'ai fais sur WindPath \n"+Dashboard.text));
        
    }
    
    public void ShareToFB()
    {

    
        Application.OpenURL(FB_ADDRESS);
        
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
