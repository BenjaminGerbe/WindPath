using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatWindManager : MonoBehaviour
{
    /// <summary>
    /// Script fait par SONTOT Alexis 
    /// Utilisé pour : Contrôler l'interaction vent/bateau
    /// </summary>
    // Start is called before the first frame update

    [Header("Components")]
    public WindControl windControl;
    public Rigidbody rigidbodyBoat;

    [Header("Values")]
    [Range(0f,1f)]
    public float coeffWind =1;
    



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(windControl.GetVectorWind());
        rigidbodyBoat.velocity += windControl.GetVectorWind()*coeffWind;
    }
}
