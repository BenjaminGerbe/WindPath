using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "IaPreset", menuName = "ScriptableObjects/IaPreset", order = 1)]
public class IaBoatControllerPreset : ScriptableObject
{
     
    [Header("Values")] 
    public float moveSpeed;
    public float torqueSpeed;
    public float MaxVitesse;
    public float MaxRotationVitesse;
    
    [Range(0f,1f)]
    public float coeffWind =1;
    public AnimationCurve WindInpact;
    
}
