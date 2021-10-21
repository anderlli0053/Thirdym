using UnityEngine;
using UnityEditor;
using Gann4Games.Thirdym.Utility;

namespace Gann4Games.EditorTools
{
    [CustomEditor(typeof(HealthHandler))]
    public class HealthHandlerInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            HealthHandler healthHandler = (HealthHandler)target;
            EditorGUILayout.Slider("Health percentage (%)", healthHandler.HealthPercentage * 100, 0, 100);
        }
    }
}
