using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioMixerManagement : MonoBehaviour
{

    public AudioMixer AM;
    public Slider slider;
    


    public void setVolume(string param)
    {
        
        PlayerPrefs.SetFloat(param,Mathf.Log10(slider.value) * 20.0f);
        PlayerPrefs.SetFloat(param+"Slider",slider.value);
        AM.SetFloat(param, Mathf.Log10(slider.value) * 20.0f);
        
    }
    
   
}
