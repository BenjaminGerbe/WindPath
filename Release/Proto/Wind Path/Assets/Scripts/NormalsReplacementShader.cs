using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalsReplacementShader : MonoBehaviour
{
    [SerializeField]
    Shader normalsShader;


    private RenderTexture renderTexture;
    private Camera nCamera;

    // Start is called before the first frame update
    void Start()
    {
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


    }

}
