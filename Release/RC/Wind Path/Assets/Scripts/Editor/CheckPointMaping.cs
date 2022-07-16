using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CheckPointMaping : EditorWindow
{
    
    private Event e;

    public Checkpoints checkpoints;
    public List<Collider> lstCheckPoints;
    public GameObject[] Boats;
    private bool loaded = false;
    public bool addTarget = false;
    Vector2 mousePos;

    private Vector3[] newCollider;
    private int index = 0;
    private bool stopCreation = false;
    
    [MenuItem ("Race/CheckPointMaping")]
    public static void  ShowWindow () {
        CheckPointMaping window = (CheckPointMaping)EditorWindow.GetWindow(typeof(CheckPointMaping));
        window.Show();
    }
    
    
    
    void OnGUI () {
        // The actual window code goes here
        e = Event.current;

        if (loaded)
        {
            EditorGUILayout.LabelField("Ajouter des target point pour les IA", EditorStyles.largeLabel);
            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Add"))
            {
             
                addTarget = true;
            }
        
            if (GUILayout.Button("Cancel"))
            {
                newCollider = new Vector3[2];
                index = 0;
                addTarget = false;
            }
        
       
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Manage Points", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
    
            if (GUILayout.Button("Load"))
            {
                lstCheckPoints = checkpoints.Checkpoint;
                UpdateDraw();
            }
        
            if (GUILayout.Button("RemoveLast"))
            {
                if (lstCheckPoints.Count > 0)
                {
                    Collider go = lstCheckPoints[lstCheckPoints.Count-1];
                    lstCheckPoints.RemoveAt(lstCheckPoints.Count-1);
                    DestroyImmediate(go.gameObject);
                
                    checkpoints.Checkpoint = lstCheckPoints;
                    UpdateDraw();
                }
                
             
            }

    
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
      
        



        }
        else
        {
            EditorGUILayout.LabelField("La carte n'est pas correctement chargé", EditorStyles.boldLabel);
        }
       
        
 
        
        
    }

    
    private void OnEnable()
    {
        checkpoints = GameObject.FindObjectOfType<Checkpoints>();
        
        newCollider = new Vector3[2];
        
        
        
        Boats = GameObject.FindGameObjectsWithTag("Boat");

        lstCheckPoints = new List<Collider>();
            
        if (checkpoints != null )
        {
            loaded = true;


            foreach (Collider Col in checkpoints.Checkpoint)
            {

                lstCheckPoints.Add( Col);
            }
  
        }

       
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

    
    void UpdateDraw()
    {
        if (lstCheckPoints != null)
        {
            for (int i = 0; i < lstCheckPoints.Count; i++)
            {

                Handles.color = Color.green;
                //Handles.DrawWireDisc(lstCheckPoints[i].transform.position, Vector3.up, 30f);
                
                
                Handles.color = Color.magenta;

                Collider col = lstCheckPoints[i];

                if (col == null) continue;
                
                float distance = (col.bounds.max - col.bounds.min).magnitude;
                
                
                //Handles.DrawLine(col.bounds.center -col.bounds.extents,col.bounds.center +col.bounds.extents,5f);
                Handles.DrawLine(col.bounds.center + new Vector3(0,5,0), ( col.bounds.center + col.transform.right * (distance/2.0f) ) +  new Vector3(0,5,0)  ,10f);
                Handles.DrawLine(col.bounds.center + new Vector3(0,5,0) , (col.bounds.center - col.transform.right * (distance/2.0f) ) +  new Vector3(0,5,0) ,10f);
                
                
                Handles.color = Color.red;
                Handles.DrawWireDisc(( col.bounds.center + col.transform.right * (distance/2.0f) ) , Vector3.up, 2f );

                Handles.color = new Color(0.0f, 0f, 0.5f, 0.4f);
                Handles.DrawSolidDisc(( col.bounds.center + col.transform.right * (distance/2.0f) ), Vector3.up, 2f );
                
                Handles.color = Color.red;
                Handles.DrawWireDisc((col.bounds.center - col.transform.right * (distance/2.0f) ), Vector3.up, 2f );

                Handles.color = new Color(0.0f, 0f, 0.5f, 0.4f);
                Handles.DrawSolidDisc((col.bounds.center - col.transform.right * (distance/2.0f) ), Vector3.up, 2f );

                Handles.color = Color.black;


                GUIStyle g = new GUIStyle();
                g.fontSize = 15;
                
                
                Handles.Label(col.bounds.center + new Vector3(0,15,0),col.name,g);
            
            }
        }
        
        
        if (newCollider != null)
        {
            for (int i = 0; i < newCollider.Length; i++)
            {

                Handles.color = Color.red;
                Handles.DrawWireDisc(newCollider[i], Vector3.up, 2f );

                Handles.color = new Color(0.0f, 0f, 0.5f, 0.4f);
                Handles.DrawSolidDisc(newCollider[i], Vector3.up, 2f );

                
     

            }
        }
        
    }
    
    void OnScene(SceneView scene)
    {

        UpdateDraw();
        
        if(e== null) return;
        
        
        float ppp = EditorGUIUtility.pixelsPerPoint;
        
        mousePos = e.mousePosition;
        mousePos.y = scene.camera.pixelHeight - mousePos.y * ppp;
        mousePos.x *= ppp;

        

      if (e.type == EventType.ValidateCommand && e.commandName == "UndoRedoPerformed")
      {
          lstCheckPoints.RemoveAt(lstCheckPoints.Count-1);
          checkpoints.Checkpoint = lstCheckPoints;
      }
      

        if ( e.button == 1  && e.type == EventType.MouseDown && addTarget)
        {
            RaycastHit hit;

            
            Ray ray = scene.camera.ScreenPointToRay(mousePos);
        
            if (Physics.Raycast(ray, out hit)) {

                if (this != null)
                {
                    EditorUtility.SetDirty(this);
                    
                   
                }

                if (index < 2)
                {
                    newCollider[index] = hit.point;
                    index++;

                }
               
            }
            
          
            
            e.Use();
        }


        if (index >= 2)
        {
           
            try
            {
                if (stopCreation)
                {
                    return;
                }
                
                GameObject go = new GameObject();
                BoxCollider box = go.AddComponent<BoxCollider>();
                box.isTrigger = true;
                box.gameObject.layer = checkpoints.gameObject.layer;
                Vector3 dir =  (newCollider[1] - newCollider[0]).normalized;
                float distance =  (newCollider[1] - newCollider[0]).magnitude;
                go.tag = "Checkpoint";
                Vector3 center = newCollider[1] - dir * (distance / 2.0f);
                
                go.transform.position = center;
                
                go.transform.rotation = Quaternion.LookRotation(dir );
                go.transform.Rotate(Vector3.up,90.0f);
                
                box.size = new Vector3(distance,15,2f);
                
                lstCheckPoints.Add(box );
                checkpoints.Checkpoint = lstCheckPoints;
                go.transform.SetParent(checkpoints.transform);
                go.name = "checkpoint-"+ checkpoints.transform.childCount.ToString();
                
                newCollider = new Vector3[2];
                index = 0;

                addTarget = false;
                
                
                
                Undo.RegisterCreatedObjectUndo(go, "Checkpoint");
                EditorUtility.SetDirty(go);   
                
                
            }catch (Exception exception)
            {
                Debug.LogError("Erreur dans la création du checkpoint");
                stopCreation = true;
            }


        }
        
    }
    
    
}
