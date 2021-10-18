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
        /// <returns>The file that was created as an object</returns>
        public static object Create(Object scriptableObjectClass, string filename, string folder="")
        {
        // Set the file name
            string fullFilename = filename + ".asset";

        // Set the path
            string path = "Assets/Gann4Games/Resources/ScriptableObjects/" + folder + "/" + fullFilename;

        // Create asset file
            AssetDatabase.CreateAsset(scriptableObjectClass, path);

        // Show file in project window
            EditorUtility.FocusProjectWindow();
            
        // Select file to display its information in inspector
            Selection.activeObject = scriptableObjectClass;

            return scriptableObjectClass as ScriptableObject;
        }
        public static object CreateWeapon(SO_WeaponPreset weapon, string filename) => Create(weapon, filename, "Weapons");
    }
}
