using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeLoader : MonoBehaviour
{
    
    public AudioMixer AM;
    public string[] Params;

    public Slider[] sliders;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Params.Length; i++)
        {
            string P = Params[i];
            
            if (sliders != null && sliders.Length == Params.Length)
            {
                Slider s = sliders[i];
                if (PlayerPrefs.HasKey(P + "Slider"))
                {
                    s.SetValueWithoutNotify(PlayerPrefs.GetFloat(P+"Slider"));
                }

            }
        
            
            AM.SetFloat(P, PlayerPrefs.GetFloat(P));
         
        }
    }


}
