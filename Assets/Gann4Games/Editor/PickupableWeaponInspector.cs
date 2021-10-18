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

// Creating new fields
            #region Scriptable Object field
            EditorGUILayout.BeginHorizontal();
            
            // ScriptableObject field
            var weaponDataField = EditorGUILayout.ObjectField("Weapon data", weapon.weaponData, typeof(SO_WeaponPreset), false) as SO_WeaponPreset;
            
            // Button "create" field
            if(GUILayout.Button("Create"))
                weaponDataField = ScriptableObjectTools.CreateWeapon(new SO_WeaponPreset(), target.name) as SO_WeaponPreset;

            // Override original field
            weapon.weaponData = weaponDataField;

            EditorGUILayout.EndHorizontal();

            // Message box
            if (weaponDataField == null) EditorGUILayout.HelpBox(new GUIContent().text = "'Weapon data' field can't be empty!", MessageType.Warning);
            #endregion

// Overriding original fields
            EditorGUILayout.Space();
            weapon.onPickupSFX = EditorGUILayout.ObjectField("On Pickup SFX", weapon.onPickupSFX, typeof(AudioClip), false) as AudioClip;
            weapon.collisionSoftSFX = EditorGUILayout.ObjectField("Collision Soft SFX", weapon.collisionSoftSFX, typeof(AudioClip), false) as AudioClip;
            weapon.collisionMediumSFX = EditorGUILayout.ObjectField("Collision Medium SFX", weapon.collisionMediumSFX, typeof(AudioClip), false) as AudioClip;

// Drawing original inspector
            //base.OnInspectorGUI();
        }
    }
}
