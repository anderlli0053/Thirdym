using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using Gann4Games.Thirdym.ScriptableObjects;

[ExecuteInEditMode]
public class PlayerPreferences : MonoBehaviour
{
    [System.Serializable]
    public class PlayerPreferencesJson
    {
        public int choosen_suit;
        public float audio_master=1;
        public float audio_environment=1;
        public float audio_music=1;
        public float audio_effects=1;
        public bool graphics_bloom = true;
        public bool graphics_toneMapping = true;
        public bool graphics_whiteBalance = true;
        public int weapons_pistolSlot = 0;
        public int weapons_automaticSlot = 0;
        public int weapons_shotgunSlot = 0;
        public int weapons_energySlot = 0;
        public bool weapons_havePistol = false;
        public bool weapons_haveAutomatic = false;
        public bool weapons_haveShotgun = false;
        public bool weapons_haveEnergyBased = false;
        public bool weapons_haveDefibrilators = false;
    }

    public static PlayerPreferences instance;

    public PlayerPreferencesJson json_structure;
    string json_filename => "PlayerPreferences.json";
    string json_path => Application.streamingAssetsPath;

    public SO_RagdollPreset[] suit_list;
    public int suit_count => suit_list.Length;
    public int choosen_suit;
    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;

        json_structure = new PlayerPreferencesJson();
        LoadJsonPreferences();
        suit_list = Resources.LoadAll<SO_RagdollPreset>("ScriptableObjects\\Characters");
        Debug.Log("[PlayerPreferences.cs] Resources loaded.");
    }
    public void RefreshJsonFile()
    {
        WriteJson(json_structure, json_path, json_filename);
    }
    void WriteJson(object data, string path, string filename)
    {
        File.WriteAllText(path + "\\" + filename, JsonConvert.SerializeObject(data, Formatting.Indented));
    }
    void LoadJsonPreferences()
    {
        json_structure.choosen_suit = choosen_suit;
        
        if (!File.Exists(json_path + "\\" + json_filename)) WriteJson(json_structure, json_path, json_filename);
        else json_structure = JsonConvert.DeserializeObject<PlayerPreferencesJson>(File.ReadAllText(json_path + "\\" + json_filename));

        if (json_structure.choosen_suit >= suit_count) json_structure.choosen_suit = suit_count - 1;
        WriteJson(json_structure, json_path, json_filename);
    }
    public PlayerPreferencesJson GetJsonData()
    {
        return JsonConvert.DeserializeObject<PlayerPreferencesJson>(File.ReadAllText(json_path + "\\" + json_filename));
    }
}
