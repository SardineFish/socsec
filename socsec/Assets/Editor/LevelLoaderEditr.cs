using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

namespace Assets.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(LevelLoader))]
    public class LevelLoaderEditr:UnityEditor.Editor
    {
        SceneAsset scene;
        bool showSceneList = true;
        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            /*var levelLoader = target as LevelLoader;
            var paths = AssetBundle.LoadFromFile("Assets").GetAllScenePaths();
            */
            scene = EditorGUILayout.ObjectField("Scene", scene, typeof(SceneAsset), true) as SceneAsset;
            showSceneList = EditorGUILayout.Foldout(showSceneList, "Available Scenes");
            if (showSceneList)
            {
                GUIStyle style = new GUIStyle();
                style.margin.left = 20;
                EditorGUILayout.BeginVertical(style);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Count:", GUILayout.Width(20));

            }
        }
    }
}
