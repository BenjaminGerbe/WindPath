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

    [Header("Conpenents")] 
    public TextMeshProUGUI txt;

    public CalculatePositionScripts CPS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "#"+CPS.getPosition(this.transform).ToString();
    }
}
