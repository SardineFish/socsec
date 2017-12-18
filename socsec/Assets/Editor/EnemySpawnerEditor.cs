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
        
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var spawner = target as EnemySpawner;
            var spawnPoints = new List<GameObject>();
            for(var i = 0; i < spawner.transform.childCount; i++)
            {
                if (spawner.transform.GetChild(i).tag == "Waypoints")
                    spawnPoints.Add(spawner.transform.GetChild(i).gameObject);
            }
            spawner.SpawnPoints = spawnPoints.ToArray();
            //spawner.SpawnPoint = EditorGUILayout.ObjectField("Spawn Point:", spawner.SpawnPoint, typeof(GameObject), true) as GameObject;
            

        }
    }
}
