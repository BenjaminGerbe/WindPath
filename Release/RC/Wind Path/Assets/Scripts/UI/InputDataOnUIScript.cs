using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputDataOnUIScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par GERBE benjamin 
    /// Utilis� pour : envoyer la position à l'ui
    /// </summary>
    ///


    [Header("Position")] 
    public TextMeshProUGUI txtPosition;
    public CalculatePositionScripts CPS;
    
    
    [Header("Tour")]
    public TextMeshProUGUI txtTour;
    public CountTour CT;

    [Header("Finish")]
    public GameObject Pannel;
    public TextMeshProUGUI Position;
    public TextMeshProUGUI Time;


    private RacingManager RM;

    private bool finish = false;
    
    // Start is called before the first frame update
    void Start()
    {
        RM = GameObject.FindObjectOfType<RacingManager>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CT.isFinish() && finish == false)
        {
            finish = true;
            txtTour.enabled = false;
            Pannel.SetActive(true);
            Time.text = RM.getTime();
            txtPosition.enabled = false;
            Position.text = CPS.getPosition(this.transform).ToString();
        }




        txtPosition.text = "#" + CPS.getPosition(this.transform).ToString();
        txtTour.text = CT.getTour().ToString() +"/"+CT.nbTour.ToString();
    }
}
