using UnityEngine;
using UnityEditor;
using Gann4Games.Thirdym.Events;

namespace Gann4Games.EditorTools
{
    [CustomEditor(typeof(CharacterMeleeHandler))]
    public class CharacterMeleeHandlerInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CharacterMeleeHandler component = (CharacterMeleeHandler)target;

            if (!component.animationEvents)
                EditorGUILayout.HelpBox("The variable 'Animation Events' can't be empty!", MessageType.Error);
        }
    }
}
