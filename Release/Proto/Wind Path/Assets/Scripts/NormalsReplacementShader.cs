using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalsReplacementShader : MonoBehaviour
{
    [SerializeField]
    Shader normalsShader;


    private RenderTexture renderTexture;
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        Camera thisCamera = GetComponent<Camera>();


        renderTexture = new RenderTexture(thisCamera.pixelWidth, thisCamera.pixelHeight, 24);
        
        Shader.SetGlobalTexture("_CameraNormalsTexture",renderTexture);

        GameObject copy = new GameObject("Normals camera");
        camera = copy.AddComponent<Camera>();
        camera.CopyFrom(thisCamera);
        camera.transform.SetParent(this.transform);
        camera.targetTexture = renderTexture;
        camera.SetReplacementShader(normalsShader,"RenderType");
        camera.depth = thisCamera.depth - 1;

        
    }

}
