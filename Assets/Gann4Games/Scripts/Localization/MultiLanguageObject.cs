using UnityEngine;
using TMPro;

namespace Gann4Games.Thirdym.Localization
{
    public class MultiLanguageObject : MonoBehaviour
    {
        TextMeshPro textObject;
        public string English;
        public string Español;
        private void Start()
        {
            textObject = GetComponentInChildren<TextMeshPro>();
        }
        private void Update()
        {
            if (LanguagePrefs.Language == AvailableLanguages.English)
                textObject.text = English;
            else if (LanguagePrefs.Language == AvailableLanguages.Español)
                textObject.text = Español;
        }
    }
}