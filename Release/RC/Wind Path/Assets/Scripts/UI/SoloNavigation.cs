using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("GameType") && PlayerPrefs.GetString("GameType")=="Solo")
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
