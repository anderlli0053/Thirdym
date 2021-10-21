using UnityEngine;
using UnityEditor;
using Gann4Games.Thirdym.ScriptableObjects;

namespace Gann4Games.EditorTools
{
    [CustomEditor(typeof(PickupableWeapon))]
    public class PickupableWeaponInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            PickupableWeapon weapon = (PickupableWeapon)target;

            base.OnInspectorGUI();

            if (weapon.weaponData == null)
            {
                // Message box
                EditorGUILayout.HelpBox(new GUIContent().text = "'Weapon data' field can't be empty!", MessageType.Warning);

                // "Create data" button
                if(GUILayout.Button("Create data"))
                    weapon.weaponData = ScriptableObjectTools.CreateWeapon(new SO_WeaponPreset(), target.name) as SO_WeaponPreset; ;
            }
            else
            {
                EditorGUILayout.Space();

                EditorGUILayout.BeginHorizontal();
                //
                if(GUILayout.Button("Open weapon data"))
                    ScriptableObjectTools.ShowAssetInProjectWindow(weapon.weaponData);
                if (GUILayout.Button("Open bullet data"))
                    ScriptableObjectTools.ShowAssetInProjectWindow(weapon.weaponData.bulletType);
                //
                EditorGUILayout.EndHorizontal();
            }
        }
    }
}
