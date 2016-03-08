﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using BulletUnity;

[CustomEditor(typeof(BConvexTriangleMeshShape))]
public class BConvexTriangleShapeEditor : Editor {

    BConvexTriangleMeshShape script;
    SerializedProperty hullMesh;

    void OnEnable()
    {
        script = (BConvexTriangleMeshShape)target;
        GetSerializedProperties();
    }

    void GetSerializedProperties()
    {
        hullMesh = serializedObject.FindProperty("hullMesh");
    }

    public override void OnInspectorGUI()
    {
        if (script.transform.localScale != Vector3.one)
        {
            EditorGUILayout.HelpBox("This shape doesn't support scale of the object.\nThe scale must be one", MessageType.Warning);
        }
        EditorGUILayout.PropertyField(hullMesh);
        serializedObject.ApplyModifiedProperties();
    }
}