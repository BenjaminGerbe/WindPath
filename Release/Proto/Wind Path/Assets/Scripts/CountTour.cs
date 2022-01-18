using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTour : MonoBehaviour
{

    private int ActualTour = 0;
    public int nbTour;
    public Collider finish_line;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ActualTour++;
        Debug.Log(ActualTour);
    }
}
