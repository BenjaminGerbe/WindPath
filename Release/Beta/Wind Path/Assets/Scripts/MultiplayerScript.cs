using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerScript : MonoBehaviour
{

    public List<GameObject> boats;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("GameType") && PlayerPrefs.GetString("GameType")=="Solo")
        {
            boats[0].active=false;
            cam.rect = new Rect(-0.5f, 0.0f, 2.0f, 1.0f);
        }
        else
        {
            boats[1].active = false;
        }
    }
}
