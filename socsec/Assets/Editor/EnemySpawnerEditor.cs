using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

namespace Assets.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(EnemySpawner))]
    public class EnemySpawnerEditor:UnityEditor.Editor
    {
        bool showSpawnPoints = false;
        bool showSpawnableEnemies = true;
        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            var spawner = target as EnemySpawner;
            var spawnPoints = new List<GameObject>();
            for(var i = 0; i < spawner.transform.childCount; i++)
            {
                if (spawner.transform.GetChild(i).tag == "Waypoint")
                    spawnPoints.Add(spawner.transform.GetChild(i).gameObject);
            }
            spawner.SpawnPoints = spawnPoints.ToArray();
            //spawner.SpawnPoint = EditorGUILayout.ObjectField("Spawn Point:", spawner.SpawnPoint, typeof(GameObject), true) as GameObject;
            

            showSpawnPoints = EditorGUILayout.Foldout(showSpawnPoints, "Spawn Points: " + spawner.SpawnPoints.Length.ToString());
            if (showSpawnPoints)
            {
                GUIStyle style = new GUIStyle();
                style.margin.left = 20;
                EditorGUILayout.BeginVertical(style);
                foreach (var point in spawner.SpawnPoints)
                {
                    EditorGUILayout.ObjectField(point, typeof(GameObject), true);
                }
                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.Space();

            spawner.SpawnRadius = EditorGUILayout.FloatField("Spawn Radius", spawner.SpawnRadius);
            spawner.SpawnDuration = EditorGUILayout.FloatField("Spawn Duration", spawner.SpawnDuration);
            spawner.RandomSpawn = EditorGUILayout.Toggle("Random Time", spawner.RandomSpawn);
            spawner.RandomRange = EditorGUILayout.FloatField("Range of Time", spawner.RandomRange);

            EditorGUILayout.Space();

            showSpawnableEnemies = EditorGUILayout.Foldout(showSpawnableEnemies, "Spawnable Enemies: " + spawner.SpawnableEnemies.Length.ToString());
            if (showSpawnableEnemies)
            {

                GUIStyle style = new GUIStyle();
                style.margin.left = 20;
                EditorGUILayout.BeginVertical(style);

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Count:", GUILayout.Width(60));
                var count = EditorGUILayout.IntField(spawner.SpawnableEnemies.Length, GUILayout.Width(60));
                if (GUILayout.Button("+", GUILayout.Width(30)))
                    count++;
                if (GUILayout.Button("-", GUILayout.Width(30)))
                    count--;
                EditorGUILayout.EndHorizontal();
                if (count != spawner.SpawnableEnemies.Length)
                {
                    Array.Resize(ref spawner.SpawnableEnemies, count);
                    Array.Resize(ref spawner.SpawnWeight, count);
                }

                for(var i = 0; i < count; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    spawner.SpawnableEnemies[i] = EditorGUILayout.ObjectField(spawner.SpawnableEnemies[i], typeof(GameObject), true,GUILayout.Width(150)) as GameObject;
                    //EditorGUILayout.Space();
                    EditorGUILayout.LabelField("Spawn Weight:", GUILayout.Width(90));
                    spawner.SpawnWeight[i] = EditorGUILayout.IntField(spawner.SpawnWeight[i]);
                    EditorGUILayout.EndHorizontal();
                }

                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.Space();
        }
    }
}
