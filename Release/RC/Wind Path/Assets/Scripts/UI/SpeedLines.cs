using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLines : MonoBehaviour
{
    public ParticleSystem PS;
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var shapeModule = PS.shape;
        if (PlayerPrefs.HasKey("GameType") && PlayerPrefs.GetString("GameType") == "Multi")
        {
            shapeModule.radius = Mathf.Lerp(19,13,(cam.fieldOfView-50)/65 );
        }
        else
        {
            shapeModule.radius = Mathf.Lerp(20,13,(cam.fieldOfView-70)/80 );
        }
        
     
    }
}
