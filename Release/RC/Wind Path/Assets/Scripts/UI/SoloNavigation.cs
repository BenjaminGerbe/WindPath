using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloNavigation : MonoBehaviour
{
    public GameObject go;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetString("GameType")=="Solo")
        {
            go.gameObject.SetActive(false);
        }
        else
        {
            go.gameObject.SetActive(true);
        }
    }



}
