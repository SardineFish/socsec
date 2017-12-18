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
    [CustomEditor(typeof(MapLoader))]
    public class MapLoaderEditr:UnityEditor.Editor
    {
        SceneAsset scene;
        bool showSceneList = true;
        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            var mapLoader = target as MapLoader;
            /*var paths = AssetBundle.LoadFromFile("Assets").GetAllScenePaths();
            */
            scene = EditorGUILayout.ObjectField("Scene", scene, typeof(SceneAsset), true) as SceneAsset;
            showSceneList = EditorGUILayout.Foldout(showSceneList, "Available Scenes");
            if (showSceneList)
            {
                GUIStyle style = new GUIStyle();
                EditorGUILayout.BeginVertical(style);
                style.margin.left = 20;

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Count:", GUILayout.Width(60));
                var count = EditorGUILayout.IntField(mapLoader.AvailableScenes.Count, GUILayout.Width(60));
                if (GUILayout.Button("+", GUILayout.Width(30)))
                    count++;
                if (GUILayout.Button("-", GUILayout.Width(30)))
                    count--;
                EditorGUILayout.EndHorizontal();
                if (count < mapLoader.AvailableScenes.Count)
                    mapLoader.AvailableScenes.RemoveRange(count, mapLoader.AvailableScenes.Count - count);
                else if (count > mapLoader.AvailableScenes.Count)
                    mapLoader.AvailableScenes.AddRange(new string[count - mapLoader.AvailableScenes.Count]);

                EditorGUILayout.BeginVertical();
                for (var i = 0; i < mapLoader.AvailableScenes.Count; i++)
                {
                    var scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(mapLoader.AvailableScenes[i]);
                    scene = EditorGUILayout.ObjectField("Map-" + i.ToString(), scene, typeof(SceneAsset), true) as SceneAsset;
                    if (scene != null)
                    {
                        mapLoader.AvailableScenes[i] = AssetDatabase.GetAssetPath(scene);
                    }
                }
                EditorGUILayout.EndVertical();

                

                /*VerticalBlock(
                    HorizontalBlock(
                        Text("Count:"),
                        Text(list.Count),
                        Button("+", ButtonAddClick),
                        Button("-", ButtonRemoveClick),
                        ),
                    VerticalBlock(
                        ObjectEditor("Item:", List[0]),
                        ObjectEditor("Item:", List[1]),
                        ObjectEditor("Item:", List[2]),

                        )
                    );*/
            }
        }
    }
}
