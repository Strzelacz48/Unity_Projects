using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshCombiner))]
public class MeshCombinerEditor : Editor
{
    MeshCombiner mc;
    private void Start() {
        mc = target as MeshCombiner;
    }
    
    private void OnSceneGUI() {
        if (Handles.Button(mc.transform.position + Vector3.up * 5, Quaternion.LookRotation(Vector3.up), 1, 1, Handles.SphereHandleCap))
        {
            mc.CombineMeshes();
        }
   }
}
