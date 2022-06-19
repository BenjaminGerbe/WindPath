using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerScript : MonoBehaviour
{

    public List<GameObject> boats;
    public List<Camera> cam;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("GameType") && PlayerPrefs.GetString("GameType")=="Multi")
        {
            boats[1].SetActive(false);
        }
        else
        {
            boats[0].SetActive(false);
            cam[0].rect = new Rect(-0.5f, 0.0f, 2.0f, 1.0f);
            cam[1].gameObject.SetActive(false);
        }
    }
}
