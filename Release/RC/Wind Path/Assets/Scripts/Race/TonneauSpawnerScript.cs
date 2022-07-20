using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonneauSpawnerScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par : Benjamin
    /// Utilisé pour : Générer les tonneaux
    /// </summary>
    
    [Header("Compenent")]
    public GameObject Tonneau;

    public AudioSource AS;
    public float Timer = 10f;
    
    private bool spawn = false;
    private float counter;
    
    
    public void Spawn()
    {
        spawn = true;
    }
    
    // Start is called before the first frame update
    void Start()
    {

        counter = Timer;
        GameObject go = Instantiate(Tonneau,this.transform.position,Quaternion.identity);
        go.transform.SetParent(this.transform);
   
       
        
    }

    public void startEffect()
    {
        AS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            counter -= Time.deltaTime;

            if (counter <= 0)
            {
                GameObject go = Instantiate(Tonneau,this.transform.position,Quaternion.identity);
                go.transform.SetParent(this.transform);
                counter = Timer;
                spawn = false;
            }
            
        }
    }
}
