using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Range : MonoBehaviour
{
    public MeshRenderer MR;
   

    public GameObject Boat;
    public Color color;
    public Color Detectedcolor;
    public float RangeCanon = 10f;
    public float AngleCanon = 30f;

    private GameObject detectedBoat;
    private GameObject[] Boats;
    private bool detectBoat;
    private Material coneMat;

    public GameObject getDetectedBoat()
    {
        return detectedBoat;
    }
    
    // Start is called before the first frame update
    void Start()
    { 
     
        Boats = GameObject.FindGameObjectsWithTag("Boat");
        coneMat = new Material(Shader.Find("Unlit/Cone"));

        MR.material = coneMat;
    }

    public void Detect()
    {
        detectBoat = false;
        detectedBoat = null;
        foreach (GameObject go in Boats)
        {
            if (go != Boat)
            {
                Vector3 boatplan =  Vector3.ProjectOnPlane(go.transform.position, Vector3.up);
                Vector3 planPos = Vector3.ProjectOnPlane(this.transform.position, Vector3.up);
                float distance = Mathf.Abs(Vector3.Distance(boatplan, planPos));

                Vector3 dir = go.transform.position - this.transform.position;
                
                float angle = Mathf.Abs(Vector3.SignedAngle(dir, Boat.transform.forward, Vector3.up));
                
            

                if (distance <= RangeCanon  && angle <= AngleCanon)
                {
                    detectBoat = true;
                
                    if (detectedBoat != null)
                    {
                        float distance1 = Mathf.Abs(Vector3.Distance(detectedBoat.transform.position, this.transform.position));

                        if (distance < distance1)
                        {
                            detectedBoat = go;
                        }
                        
                    }

                    detectedBoat = go;

                } 

            }

        }
    }
    
    // Update is called once per frame
    void Update()
    {
        Detect();
        
        if (coneMat != null)
        {
            coneMat.SetVector("targetPoint",this.transform.position);
            coneMat.SetFloat("Range",RangeCanon);
            coneMat.SetFloat("Angle",AngleCanon);

            if (detectBoat)
            {
                coneMat.SetColor("ColorCone",Detectedcolor);
            }
            else
            {
                coneMat.SetColor("ColorCone",color);
            }
           
        }
        
        this.transform.parent.rotation = Quaternion.LookRotation(this.Boat.transform.forward);
        
    }
}
