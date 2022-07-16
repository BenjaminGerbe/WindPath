using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalsReplacementShader : MonoBehaviour
{
    [SerializeField]
    Shader normalsShader;

    public Camera CurrentCamera;
    public LayerMask BufferLayer;
    
    private RenderTexture renderTexture;
    private Camera nCamera;

    // Start is called before the first frame update
    void Start()
    {
       
        /*
        Camera thisCamera = GetComponent<Camera>();


        renderTexture = new RenderTexture(thisCamera.pixelWidth, thisCamera.pixelHeight, 24);
        
        Shader.SetGlobalTexture("_CameraNormalsTexture",renderTexture);

        GameObject copy = new GameObject("Normals camera");
        nCamera = copy.AddComponent<Camera>();
        nCamera.CopyFrom(thisCamera);
        nCamera.transform.SetParent(this.transform);
        nCamera.targetTexture = renderTexture;
        nCamera.SetReplacementShader(normalsShader,"RenderType");
        nCamera.depth = thisCamera.depth - 1;
        */
        
        Camera thisCamera = GetComponent<Camera>();

        
        Debug.Log("test");
        
      
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        
        Shader.SetGlobalTexture("_CameraColorScene",renderTexture);

        GameObject copy = new GameObject("SceneColor");
        nCamera = copy.AddComponent<Camera>();
        nCamera.CopyFrom(thisCamera);
        nCamera.transform.SetParent(this.transform);
        nCamera.targetTexture = renderTexture;
        nCamera.depth = thisCamera.depth - 1;
        nCamera.cullingMask = BufferLayer;


    }

    private void Update()
    {
        nCamera.fieldOfView = CurrentCamera.fieldOfView;
        nCamera.rect = CurrentCamera.rect;
    }
}
