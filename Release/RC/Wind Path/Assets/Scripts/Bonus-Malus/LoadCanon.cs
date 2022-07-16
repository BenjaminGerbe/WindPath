using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCanon : MonoBehaviour
{
    public Range range;


    public Range getRange()
    {
        return range;
    }
    public void OpenRange()
    {
        range.gameObject.SetActive(true);
    }
    
    public void CloseRange()
    {
      
        range.gameObject.SetActive(false);
    }
    
}
