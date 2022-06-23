using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public enum ModePosition
{
    CalculeByAngle,
    CalculeByDistance
}

[System.Serializable]
public class BoatPosition
{
    public Transform tr;
    
    
    [HideInInspector]
    public float Value;

    [HideInInspector] 
    public int Turn;
}
public class CalculatePositionScripts : MonoBehaviour
{

    /// <summary>
    /// Script fait par GERBE Benjamin 
    /// Utilisé pour :Calculer la position des joueurs
    /// </summary>
    // Start is called before the first frame update
    
    
    [Header("Conpenents")]
    public ModePosition CalculationMethode;
    public Transform StartPosition;
    public Transform origin;
    
    public List<BoatPosition> Boats;

    private GameObject[] _Boats;

    // Start is called before the first frame update
    void Start()
    {

    }


    public int getPosition(Transform tr)
    {
        int i = 0;
        bool trouver = false;


        while (!trouver && i < Boats.Count)
        {
            if (tr == Boats[i].tr)
            {
                trouver = true;
            }
            else
            {
                i++;
            }
        }

        return i+1;
    }


    // Update is called once per frame
    void Update()
    {
        Boats = Boats.OrderByDescending(x => x.Value).ToList();

        if (CalculationMethode == ModePosition.CalculeByAngle)
        {

            foreach (BoatPosition boat in Boats)
            {
                var boatPosition = boat;
       
                Vector3 direction = (boatPosition.tr.position - this.origin.position).normalized;
                Vector3 directionStart = (this.StartPosition.position - this.origin.position).normalized;


                Debug.DrawRay(this.origin.position, direction * 600, Color.blue);
                Debug.DrawRay(this.origin.position, directionStart * 600, Color.magenta);

                float angle = Vector3.SignedAngle(direction, directionStart, Vector3.up);

                angle = angle <= 0 ? angle + 360 : angle;

                boatPosition.Value = angle + (boat.tr.GetComponent<CountTour>().getCurrentTour() - 1) * 360f;
            }
        }

        if (CalculationMethode == ModePosition.CalculeByDistance)
        {
            foreach (BoatPosition boat in Boats)
            {
                int CTour = boat.tr.GetComponent<CountTour>().getTour() - 1;
                int CCheck = boat.tr.GetComponent<CountTour>().getLastCheckpointpassed();
                Collider[] check = GameObject.Find("Checkpoints").GetComponent<Checkpoints>().Checkpoint;
                float distance = 0;
                if (CCheck+1 > check.Count()-1)
                {
                    distance = Vector3.Distance(boat.tr.position, this.origin.position);
                }
                else
                {
                    distance = Vector3.Distance(boat.tr.position, check[CCheck + 1].transform.position);
                }
                boat.Value = CTour * 100000 + CCheck * 10000 - distance;
            }
        }
    }
}
