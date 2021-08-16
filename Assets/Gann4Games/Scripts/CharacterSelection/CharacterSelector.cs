using UnityEngine;
using Gann4Games.Thirdym.ScriptableObjects;
public class CharacterSelector : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textCharacter;
    public TMPro.TextMeshProUGUI textFaction;
    public UnityEngine.UI.Slider sliderHealth;
    TMPro.TextMeshProUGUI textHealth;
    public UnityEngine.UI.Slider sliderRegen;
    TMPro.TextMeshProUGUI textRegen;

    SO_RagdollPreset[] suit_list;
    int choosen_suit;

    GameObject current_suit;

    private void Start()
    {
        suit_list = PlayerPreferences.instance.suit_list;
        choosen_suit = PlayerPreferences.instance.json_structure.choosen_suit;

        textHealth = sliderHealth.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        textRegen = sliderRegen.GetComponentInChildren<TMPro.TextMeshProUGUI>();

        if (current_suit == null && transform.childCount > 0) current_suit = transform.GetChild(0).gameObject;

        LoadSuit();
        UpdateInformationLabel();
    }
    public void UpdateInformationLabel()
    {
        // Not zombie code, will show player saved content soon.
        // 
        // string saved_character_name = suit_list[PlayerPreferences.instance.json_structure.choosen_suit].character_name;
        // int saved_character_id = PlayerPreferences.instance.json_structure.choosen_suit;

        textCharacter.text = suit_list[choosen_suit].character_name+string.Format("\n(by {0})", suit_list[choosen_suit].author);
        textFaction.text = "Faction " + suit_list[choosen_suit].faction.Split('/')[1];

        sliderHealth.value = suit_list[choosen_suit].maximumHealth;
        textHealth.text = "Health (" + suit_list[choosen_suit].maximumHealth + ")";

        sliderRegen.value = suit_list[choosen_suit].regeneration_rate;
        textRegen.text = "Regeneration rate (" + suit_list[choosen_suit].regeneration_rate + ")";
    }
    public void SaveSuitSelection()
    {
        PlayerPreferences.instance.json_structure.choosen_suit = choosen_suit;
        PlayerPreferences.instance.RefreshJsonFile();
        string selected_character_name = suit_list[choosen_suit].character_name;
        NotificationHandler.Notify(string.Format("{0} was selected.", selected_character_name));
    }
    public void NextSuit()
    {
        choosen_suit += 1;
        if (choosen_suit >= PlayerPreferences.instance.suit_count) choosen_suit = 0;
        LoadSuit();
    }
    public void PrevSuit()
    {
        choosen_suit -= 1;
        if (choosen_suit < 0) { choosen_suit = PlayerPreferences.instance.suit_count - 1; }
        LoadSuit();
    }
    void LoadSuit()
    {
        RemovePreviousSuit();
        current_suit = Instantiate(suit_list[choosen_suit].battleSuit, transform.position, transform.rotation, transform);
    }
    void RemovePreviousSuit()
    {
        if (current_suit) Destroy(current_suit);
    }
}
