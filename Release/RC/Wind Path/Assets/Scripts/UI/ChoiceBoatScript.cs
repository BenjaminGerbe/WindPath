using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class boatVitrine
{
    public GameObject Modele;
    public GameObject Boat;
}
public class ChoiceBoatScript : MonoBehaviour
{

    public List<boatVitrine> Boats;
    
    public GameObject getBoat(int current)
    {
        return Boats[current % Boats.Count].Modele;
    }
    

}
