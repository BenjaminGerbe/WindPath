using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct settingsBoats
{
    /// <summary>
    /// Script fait par: Benjamin
    /// Utilisé pour : changer de bateau celon le choix du menu, et du coup bien gérer les différentes références entre les scipts
    /// </summary>
    /// 
    
    [Header("UI -- start")] 
    public TextMeshProUGUI txtPosition;
    public CalculatePositionScripts CPS;

    [Header("Tour")]
    public TextMeshProUGUI txtTour;

    [Header("Finish")]
    public GameObject Pannel;
    public TextMeshProUGUI Position;
    public TextMeshProUGUI Time;
    
    
    
    [Header("Bonus")]
    public Image ImgBonus;
    
    
    

    [Header("Conpenents")] [Header("UI -- end")]
    public CinemachineVirtualCamera CVC;
    public CinemachineVirtualCamera CVCback;
    public CinemachineBrain CB;
    public Camera Camera;
    public string playerPrefName;
    public string LayerName;
    public LayerMask LayerBasic;
    public LayerMask LayerInterior;
    public LayerMask LayerSail;
    public LayerMask LM;
    public ControllMethod CM;
    public WindControl WC;
  
    
}

public class GestionSelectedBoat : MonoBehaviour
{
    public ChoiceBoatScript CBS;
    
    public List<Transform> spawnBoat;
    public settingsBoats[] settings = new settingsBoats[2];
   
    // Start is called before the first frame update
    void Awake()
    {
        foreach (var Set in settings)
        {
            
            
            
            if(!PlayerPrefs.HasKey(Set.playerPrefName) ||  PlayerPrefs.GetInt(Set.playerPrefName) < 0 )
            {
   
                break;
            }
            
            int currentBoat = PlayerPrefs.GetInt(Set.playerPrefName);

            int d = 0;

            do
            {
                d = Random.Range(0, spawnBoat.Count);

            } while (spawnBoat[d] == null);
            
            
            GameObject go = Instantiate(CBS.Boats[currentBoat].Boat,spawnBoat[d].position , spawnBoat[d].transform.rotation);
        
            
            
            
            
            spawnBoat[d] = null;
            
            go.transform.SetParent(this.transform);
            go.name = Set.playerPrefName;
            Set.CVC.GetComponentInParent<GetBoatInfo>().boat = go;

            
            





            CameraController CCer = go.GetComponent<CameraController>();
            CCer.Camera = Set.Camera;
            CCer.CameraBack = Set.CVCback.transform.gameObject;
            CCer.CB = Set.CB;
            
            
            CCer.LMBasic = Set.LayerBasic;
            CCer.LMInterior = Set.LayerInterior;
   
            CCer.LMSAIL = Set.LayerSail;
            
            InputDataOnUIScript g = go.GetComponent<InputDataOnUIScript>();
            
         
            
            g.txtPosition = Set.txtPosition;
            g.CPS = Set.CPS;
            g.txtTour = Set.txtTour;
            g.CT =  go.GetComponent<CountTour>();
            g.Pannel = Set.Pannel;
            g.Position = Set.Position;
            g.Time = Set.Time;
            g.ImgBonus = Set.ImgBonus;
           
            
            
            ArrowScript[] ar = go.GetComponents<ArrowScript>();

            ar[0].AlignItem.gameObject.layer =  LayerMask.NameToLayer(Set.LayerName);
            ar[0].AlignItem.GetChild(0).gameObject.layer =  LayerMask.NameToLayer(Set.LayerName);
            
            
            ar[0].MBControler = Set.WC;
            
            ar[1].AlignItem.gameObject.layer = LayerMask.NameToLayer(Set.LayerName);
            ar[1].AlignItem.GetChild(0).gameObject.layer =  LayerMask.NameToLayer(Set.LayerName);


            Transform t = go.transform;


            foreach (Transform Tr in t)
            {
                CinemachineVirtualCamera CMC =  Tr.GetComponentInChildren<CinemachineVirtualCamera>();

                if (CMC)
                {
                    CMC.gameObject.layer =  LayerMask.NameToLayer(Set.LayerName);


                    CMC.transform.GetComponentInChildren<Camera>().cullingMask = Set.LM;
                    
                }
                
            }
            
         
            
            go.GetComponent<DynamicFov>().CVC = Set.CVC;
            Set.CVC.Follow = go.transform;
            Set.CVC.LookAt = go.transform;
            

            Set.CVCback.Follow = go.transform;
            Set.CVCback.LookAt = go.transform;
            
 
            go.GetComponent<BoatWindManager>().windControl = Set.WC;
            
            go.GetComponent<InputBoatScript>()._ControllMethod = Set.CM;
      
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
