using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RangeManager : MonoBehaviour
{
    
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Permet de gérer l'affichage de la zone de tir
    /// </summary>

    
    public Transform followBoat;

    public Material mat;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetVector("targetPoint",new Vector4(followBoat.position.x,followBoat.position.y,followBoat.position.z,0));
    }
}
