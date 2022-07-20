using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MultiplayerScript : MonoBehaviour
{
  
    public List<Camera> cam;
    
    public GameObject boat ;

    private void Awake()
    {
     
    }


    // Start is called before the first frame update
    void Start()
    {

   
        
        if (PlayerPrefs.HasKey("GameType") && PlayerPrefs.GetString("GameType")=="Multi")
        {
            boat.SetActive(false);
            
   
            Transform tr = cam[0].transform.GetComponent<GetBoatInfo>().boat.transform;

            foreach (Transform t in tr)
            {
              
                CinemachineVirtualCamera g = t.GetComponent<CinemachineVirtualCamera>();
                
                if (g != null)
                {
                    Camera c = g.GetComponentInChildren<Camera>();
                    c.rect = new Rect(-0.5f, 0.0f, 1.0f, 1.0f);
                    
                }
                
            }


                
                tr = cam[1].transform.GetComponent<GetBoatInfo>().boat.transform;
                
                foreach (Transform t in tr)
                {

                    CinemachineVirtualCamera g = t.GetComponent<CinemachineVirtualCamera>();
                    
                    if (g != null)
                    {
                    
                        Camera c = g.GetComponentInChildren<Camera>();
                        c.rect = new Rect(0.5f, 0.0f, 1.0f, 1.0f);
                        
                    }
                    
                }
            
                
            
            
        }
        else
        {
            cam[0].rect = new Rect(0.0f, 0.0f, 2.0f, 1.0f);
            Transform tr = cam[0].transform.GetComponent<GetBoatInfo>().boat.transform;
            
          
            cam[1].gameObject.SetActive(false);
     
            
        }
    }
}
