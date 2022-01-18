using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTour : MonoBehaviour
{

    private int ActualTour = 0;
    private bool check = true;
    public int nbTour;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="finish line" && check == true)
        {
            check = false;
            ActualTour++;
            Debug.Log(ActualTour);
        }
        if (other.name=="checkpoint")
        {
            check = true;
        }
    }
}
