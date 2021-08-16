using UnityEngine;

namespace Gann4Games.Thirdym.Localization
{
    public enum AvailableLanguages
    {
        English,
        Español
    }
    public class LanguagePrefs : MonoBehaviour
    {

        static public AvailableLanguages Language;
        private void Start()
        {
            Language = PlayerPrefs.GetInt("Language", 0) == 0 ? AvailableLanguages.English : AvailableLanguages.Español;
        }
        public void SetLanguageToEnglish()
        {
            Language = AvailableLanguages.English;
            PlayerPrefs.SetInt("Language", 0);
        }
        public void EstablecerLenguajeAEspañol()
        {
            Language = AvailableLanguages.Español;
            PlayerPrefs.SetInt("Language", 1);
        }
    }
}