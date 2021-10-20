using UnityEngine;
using UnityEditor;
using Gann4Games.Thirdym.Core;
using Gann4Games.Thirdym.ScriptableObjects;

namespace Gann4Games.EditorTools
{
    [CustomEditor(typeof(ExplosionHandler))]
    public class ExplosionHandlerInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            ExplosionHandler explosion = (ExplosionHandler)target;

            EditorGUILayout.BeginHorizontal();

            var explosiveDataField = EditorGUILayout.ObjectField("Explosive data", explosion.explosiveData, typeof(SO_ExplosionPreset), false) as SO_ExplosionPreset;

            if (GUILayout.Button("Create"))
                explosiveDataField = ScriptableObjectTools.Create(new SO_ExplosionPreset(), "NewExplosivePreset", "Explosives") as SO_ExplosionPreset;

            explosion.explosiveData = explosiveDataField;

            EditorGUILayout.EndHorizontal();

            if (explosiveDataField == null) EditorGUILayout.HelpBox(new GUIContent().text = "'Explosive data' can't be empty!", MessageType.Warning);

            base.OnInspectorGUI();
        }
    }
}
