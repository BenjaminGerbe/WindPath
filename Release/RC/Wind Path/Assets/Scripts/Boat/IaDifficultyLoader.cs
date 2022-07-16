using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoatControlleurScript))]
[RequireComponent(typeof(BoatWindManager))]
public class IaDifficultyLoader : MonoBehaviour
{
    /// <summary>
    /// Script fait par: Benjamin
    /// Utilisé pour : gérer le systeme facile dur
    /// </summary>


    [Header("Values")] 
    public IaBoatControllerPreset Easy;
    public IaBoatControllerPreset Normal;

    private BoatControlleurScript BS;
    private BoatWindManager BW;
    
    // Start is called before the first frame update
    void Start()
    {
        BS = GetComponent<BoatControlleurScript>();
        BW = GetComponent<BoatWindManager>();

        if (PlayerPrefs.HasKey("Difficulty") && PlayerPrefs.GetInt("Difficulty") == 0)
        {
            BS.moveSpeed =  Easy.moveSpeed;
            BS.torqueSpeed = Easy.torqueSpeed;
            BS.MaxVitesse = Easy.MaxVitesse;
            BS.MaxVitesse = Easy.MaxRotationVitesse;

            BW.coeffWind = Easy.coeffWind;
            BW.WindInpact = Easy.WindInpact;

        }
        else
        {
            Debug.Log("hallo");
            BS.moveSpeed =  Normal.moveSpeed;
            BS.torqueSpeed = Normal.torqueSpeed;
            BS.MaxVitesse = Normal.MaxVitesse;
            BS.MaxVitesse = Normal.MaxRotationVitesse;
            
            
            BW.coeffWind = Normal.coeffWind;
            BW.WindInpact = Normal.WindInpact;
        }
     
        
    }

}
