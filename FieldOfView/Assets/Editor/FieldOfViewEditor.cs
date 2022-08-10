using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.sightRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + fov.DirectionFromAngle(fov.sightAngle / 2) * fov.sightRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + fov.DirectionFromAngle(-fov.sightAngle / 2) * fov.sightRadius);

        Handles.color = Color.red;
        foreach(Transform target in fov.targetListInFeild)
        {
            Handles.DrawLine(fov.transform.position, target.position);
        }
    }

}
