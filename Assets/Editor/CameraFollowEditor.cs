using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraFollow))]
public class CameraFollowEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CameraFollow cf = (CameraFollow)target;
        if (GUILayout.Button("Set current position as min"))
        {
            cf.SetMinCamPosition();
        }
        if (GUILayout.Button("Set curret position as max"))
        {
            cf.SetMaxCamPosition();
        }
    }
}
