using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindControl : MonoBehaviour
{
    /// <summary>
    /// Script fait par SONTOT Alexis 
    /// Utilis� pour : Contr�ler le vent
    /// </summary>
    // Start is called before the first frame update

    private Vector2 windVector;
    private Vector2 oldWindVector;
    private Vector2 newWindVector;
    private float cnt;
    private float percent;
    private int timer;
    

    [Header("Values")]
    public float windStrength=1;
    public int cdmax;
    public float speedChange;
    
    void Start()
    {
        windVector = new Vector2(Random.Range(-1f,1f), Random.Range(-1f, 1f)) ;
        oldWindVector = windVector;
        newWindVector = windVector;
        percent = 0;
        timer = cdmax;
    }

    public Vector3 GetVectorWind()
    {
        return new Vector3 (windVector.x,0,windVector.y) * windStrength;
    }
    
    public void SetVectorWind(Vector3 vec)
    {
        
        newWindVector =vec;
        oldWindVector = windVector;
        cnt = 0;
        percent = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        cnt += Time.deltaTime;
        percent += Time.deltaTime / speedChange;
        percent = Mathf.Clamp(percent, 0, 1);
        if (cnt >= timer)
        {

            SetVectorWind(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
            
        }
        windVector = Vector2.Lerp(oldWindVector, newWindVector, percent);
    }
}
