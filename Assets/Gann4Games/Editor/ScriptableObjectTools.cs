using UnityEngine;
using UnityEditor;
using Gann4Games.Thirdym.ScriptableObjects;

namespace Gann4Games.EditorTools
{
    public class ScriptableObjectTools
    {
        /// <summary>
        /// Creates a new scriptable object of type specified type and stores the new created file into the scriptable objects folder.
        /// </summary>
        /// <returns>The object that was created</returns>
        public static object Create(Object scriptableObjectClass, string filename, string folder="")
        {
            string fullFilename = filename + ".asset";
            string path = "Assets/Gann4Games/Resources/ScriptableObjects/" + folder + "/" + fullFilename;

            AssetDatabase.CreateAsset(scriptableObjectClass, path);

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = scriptableObjectClass;

            return scriptableObjectClass as ScriptableObject;
        }
        public static object CreateWeapon(SO_WeaponPreset weapon, string filename) => Create(weapon, filename, "Weapons");
    }
}
