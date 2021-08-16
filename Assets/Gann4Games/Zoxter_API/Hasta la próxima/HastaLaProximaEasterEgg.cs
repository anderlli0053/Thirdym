using System.Collections;
using UnityEngine;
using Gann4Games.Thirdym.Localization;

public class HastaLaProximaEasterEgg : MonoBehaviour {

    private void Start()
    {
        StartCoroutine(Initialize());
    }
    IEnumerator Initialize()
    {
        yield return new WaitForSeconds(.1f);
        if (LanguagePrefs.Language == AvailableLanguages.Español)
        {
            int randint = Random.Range(0, 50);
            if (randint != 22)
            {
                print("Easter egg could not be found. N=" + randint.ToString());
                Destroy(gameObject);
            }
            else
            {
                print("EASTER EGG FOUND");
            }
        }
        else Destroy(gameObject);
    }
}
