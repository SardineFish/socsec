using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NumericColoredGUI))]
[CanEditMultipleObjects]
public class NumericColoredGUIEditor : UnityEditor.Editor
{
    bool showRange = true;
    public override void OnInspectorGUI()
    {
        var obj = target as NumericColoredGUI;
        obj.Value = EditorGUILayout.FloatField("Value", obj.Value);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ValueDisplay"));
        serializedObject.ApplyModifiedProperties();

        showRange = EditorGUILayout.Foldout(showRange, "Range & Color");
        if (showRange)
        {
            GUIStyle style = new GUIStyle();
            style.margin.left = 50;
            EditorGUILayout.BeginVertical(style);
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("+"))
                obj.ColorValueRange.Add(new ColorValueRange());
            if (GUILayout.Button("-"))
                obj.ColorValueRange.RemoveAt(obj.ColorValueRange.Count - 1);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
            foreach (var range in obj.ColorValueRange)
            {
                EditorGUILayout.BeginHorizontal();
                range.from = EditorGUILayout.FloatField(range.from);
                EditorGUILayout.LabelField("~", GUILayout.Width(20));
                range.to = EditorGUILayout.FloatField(range.to);
                range.Color = EditorGUILayout.ColorField(range.Color);
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
        }
    }
}