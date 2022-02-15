using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindControl : MonoBehaviour
{
    /// <summary>
    /// Script fait par SONTOT Alexis 
    /// Utilisé pour : Contrôler le vent
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, new Vector3(windVector.x, 0, windVector.y) * windStrength);
    }
    void Start()
    {
        windVector = new Vector2(Random.Range(-1f,1f), Random.Range(-1f, 1f)) ;
        oldWindVector = windVector;
        newWindVector = windVector;
        percent = 0;
        timer = Random.Range(1, cdmax);
    }

    public Vector3 GetVectorWind()
    {
        return new Vector3 (windVector.x,0,windVector.y) * windStrength;
    }
    // Update is called once per frame
    void Update()
    {
        cnt += Time.deltaTime;
        percent += Time.deltaTime;
        percent = Mathf.Clamp(percent, 0, 1);
        if (cnt >= timer)
        {
            newWindVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            oldWindVector = windVector;
            cnt = 0;
            percent = 0;
        }
        windVector = Vector2.Lerp(oldWindVector, newWindVector, percent/speedChange);
    }
}
