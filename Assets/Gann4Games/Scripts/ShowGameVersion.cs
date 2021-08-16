using UnityEngine;

public class ShowGameVersion : MonoBehaviour
{
    TMPro.TextMeshProUGUI textObject;
    private void Awake()
    {
        textObject = GetComponent<TMPro.TextMeshProUGUI>();
        textObject.text = Application.version;
    }
}
