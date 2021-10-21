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
            base.OnInspectorGUI();

            ExplosionHandler explosion = (ExplosionHandler)target;

            if (explosion.explosiveData == null)
            {
                EditorGUILayout.HelpBox(new GUIContent().text = "'Explosive data' can't be empty!", MessageType.Warning);
                if (GUILayout.Button("Create"))
                    explosion.explosiveData = ScriptableObjectTools.Create(new SO_ExplosionPreset(), "NewExplosivePreset", "Explosives") as SO_ExplosionPreset;
            }

        }
    }
}
