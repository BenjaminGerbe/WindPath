using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;


public class RaceMaping : EditorWindow
{
    private Event e;
    public NavMeshPath NMP;

    public MilesStoneIAScript MSIS;
    public List<Vector3> lstPointTarget;
    public GameObject[] Boats;

    public bool addTarget = false;
    Vector2 mousePos;
    
    [MenuItem ("Race/RaceIaMaping")]
    public static void  ShowWindow () {
        RaceMaping window = (RaceMaping)EditorWindow.GetWindow(typeof(RaceMaping));
        window.Show();
    }
    
    
    
    void OnGUI () {
        // The actual window code goes here
        e = Event.current;
        
        EditorGUILayout.LabelField("Ajouter des target point pour les IA", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
        {
        
            addTarget = true;
        }
        
        if (GUILayout.Button("Cancel"))
        {
            addTarget = false;
        }
        
       
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Manage Points", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
    
        if (GUILayout.Button("Load"))
        {

            lstPointTarget = MSIS.positionMilesStones;
        }
        
        if (GUILayout.Button("RemoveLast"))
        {
            lstPointTarget.RemoveAt(lstPointTarget.Count-1);
            Undo.RecordObject(this,"remove last");
        }
        
        if (GUILayout.Button("Clear"))
        {
            lstPointTarget = new List<Vector3>();
        }
    
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();
      
        
        if (GUILayout.Button("Bake"))
        {
            MSIS.positionMilesStones = lstPointTarget;
        }
        
        
        
 
        
        
    }
    
    private void OnEnable()
    {
        MSIS = GameObject.FindObjectOfType<MilesStoneIAScript>();
        lstPointTarget = new List<Vector3>();
        Boats = GameObject.FindGameObjectsWithTag("Boat");
        NMP = new NavMeshPath();
        SceneView.duringSceneGui += this.OnScene;
    }
    
    void OnFocus()
    {
        
        
        SceneView.duringSceneGui -= this.OnScene;
        
        SceneView.duringSceneGui += this.OnScene;
        
        Repaint();
    }

    void OnDestroy()
    {
        addTarget = false;
        
        SceneView.duringSceneGui -= this.OnScene;
    }
    
    void OnScene(SceneView scene)
    {
             
        if(e== null) return;
        
        
        float ppp = EditorGUIUtility.pixelsPerPoint;
        
        mousePos = e.mousePosition;
        mousePos.y = scene.camera.pixelHeight - mousePos.y * ppp;
        mousePos.x *= ppp;

        
        // ray for gizmo(disc)
      
        
       
        
        
        if (lstPointTarget.Count > 0 && Boats.Length > 0)
        {
            for (int i = 0; i < lstPointTarget.Count; i++)
            {
         
                Handles.color = Color.red;
                Handles.DrawWireDisc( lstPointTarget[i], Vector3.up, 3f);
        
                Handles.color = new Color(0.5f, 0f, 0f, 0.4f);
                Handles.DrawSolidDisc( lstPointTarget[i], Vector3.up, 3f);
                
                
                Handles.color = Color.blue;
                Handles.DrawWireDisc( lstPointTarget[i], Vector3.up, MSIS.distanceChange/2);
        
                Handles.color = new Color(0.0f, 0f, 0.5f, 0.4f);
                Handles.DrawSolidDisc( lstPointTarget[i], Vector3.up,  MSIS.distanceChange/2);
         
            }
            
            for (int j = 0; j < Boats.Length; j++)
            {
                for (int k = 0; k < lstPointTarget.Count; k++)
                {
                    
                    if (k <= 0 )
                    {
                        NavMesh.CalculatePath(Boats[j].transform.position, lstPointTarget[k], NavMesh.AllAreas, NMP);
                        
                        TraceLine(Color.red, true);
                        
                    }
                  

                    if (k >= 0 && k + 1 < lstPointTarget.Count)
                    {
                        NavMesh.CalculatePath(lstPointTarget[k], lstPointTarget[k+1], NavMesh.AllAreas, NMP);
                        
                        TraceLine(Color.red, true);
                        
                    }
                    
                    
                    if (k < lstPointTarget.Count && k+1 >= lstPointTarget.Count)
                    {
                        NavMesh.CalculatePath(lstPointTarget[k], lstPointTarget[0], NavMesh.AllAreas, NMP);

                        TraceLine(Color.blue, false);
                    }

                }
            }

        }
        
        
        if ( e.button == 1  && e.type == EventType.MouseDown && addTarget)
        {
            RaycastHit hit;

            
            Ray ray = scene.camera.ScreenPointToRay(mousePos);
        
            if (Physics.Raycast(ray, out hit)) {

                if (this != null)
                {
                    EditorUtility.SetDirty(this);
                    Undo.RecordObject(this,"Add Targer IA");
                   
                }
             
                lstPointTarget.Add(hit.point);
                
            }
            
          
            
            e.Use();
        }
        
        
        
    }


    public void TraceLine( Color c, bool straight)
    {
        for (int i = 0; i < NMP.corners.Length - 1; i++){
               
                
            Handles.color = c;

            if (straight)
            {
                Handles.DrawLine(NMP.corners[i], NMP.corners[i + 1],4f);     
            }
            Handles.DrawDottedLine(NMP.corners[i], NMP.corners[i + 1],4f);
        }
    }
    
    void  OnInspectorUpdate()
    {
        // Call Repaint on OnInspectorUpdate as it repaints the windows
        // less times as if it was OnGUI/Update
   
        
        Repaint();
    }
}
