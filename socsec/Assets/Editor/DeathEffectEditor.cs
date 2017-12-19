using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(DeathEffect))]
    public class DeathEffectEditor: UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var deathEffect = target as DeathEffect;
            DrawDefaultInspector();
        }

        
    }
}
