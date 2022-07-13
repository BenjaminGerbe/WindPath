using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class NavigationBoatScript : MonoBehaviour
{
    /// <summary>
    /// Script fait par: Benjamin
    /// Utilisé pour : faire le choix des différents bateaux
    /// </summary>

    public ControllMethod CM;
    public Transform PosBoats;
    public TextMeshProUGUI TitleBateau;
    
    
    private ChoiceBoatScript CBS;
    private List<GameObject> boats;
    private bool change = false;
    private int currentSelectedBoat = 0;
    // Start is called before the first frame update
    void Start()
    {
        CBS = GameObject.FindObjectOfType<ChoiceBoatScript>();
        boats = new List<GameObject>();
        
        PlayerPrefs.SetInt("Player1",0);
        
        if (PlayerPrefs.HasKey("GameType") && PlayerPrefs.GetString("GameType") == "Multi")
        {
            PlayerPrefs.SetInt("Player2",0);
        }
        else
        {
            PlayerPrefs.SetInt("Player2",-1);
        }
      
        
        foreach (var go in CBS.Boats)
        {
            GameObject g = Instantiate(go.Modele, PosBoats.position, PosBoats.rotation);
            g.name = go.Modele.name;
            g.transform.SetParent(this.transform);
            g.transform.localScale = new Vector3(40, 40, 40);
            g.SetActive(false);
            boats.Add(g);
        }
        
     
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        
        
        foreach (var go in boats)
        {
            go.SetActive(false);
            go.transform.RotateAround(go.transform.position,go.transform.up,20f * Time.deltaTime);
        }
        
        boats[currentSelectedBoat].SetActive(true);

        TitleBateau.text = boats[currentSelectedBoat].name;
        
        if (CM == ControllMethod.Controller)
        {
            if (Input.GetAxisRaw("HorizontalC") == 0)
            {
                change = false;
            }
            
            if (Input.GetAxisRaw("HorizontalC") > 0 && !change)
            {
                change = true;
                currentSelectedBoat = (currentSelectedBoat + 1) % boats.Count;
               
                PlayerPrefs.SetInt("Player2",currentSelectedBoat);
            }
            
            if (Input.GetAxisRaw("HorizontalC") < 0 && !change)
            {
                change = true;
                currentSelectedBoat = (currentSelectedBoat - 1) < 0 ? boats.Count -1 : currentSelectedBoat -1;
             
                PlayerPrefs.SetInt("Player2",currentSelectedBoat);
            }
        }       
        
        
        if (CM == ControllMethod.Keyboard)
        {
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                change = false;
            }
            
            if (Input.GetAxisRaw("Horizontal") > 0 && !change)
            {
                change = true;
                currentSelectedBoat = (currentSelectedBoat + 1) % boats.Count;
                PlayerPrefs.SetInt("Player1",currentSelectedBoat);
            }
            
            if (Input.GetAxisRaw("Horizontal") < 0 && !change)
            {
                change = true;
               
                currentSelectedBoat = (currentSelectedBoat - 1) < 0 ? boats.Count -1 : currentSelectedBoat -1;
                PlayerPrefs.SetInt("Player1",currentSelectedBoat);
                
            }
        }       
        
    }
}
