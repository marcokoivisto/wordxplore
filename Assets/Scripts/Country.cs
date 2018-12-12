using UnityEngine;
using TMPro;

public class Country : MonoBehaviour  {

    string fromLanguage = "en";
    public string toLanguage = "en";

    TextMeshPro textToGo;

    private void Start()
    {
        string text = "beer";
        string lang = fromLanguage + '-' + toLanguage;

        textToGo = GetComponent<TextMeshPro>();
        Translate(text, lang, textToGo);

    }

    Coroutine Translate(string text, string lang, TextMeshPro textMP) {
        return StartCoroutine(TranslateAPI.GetTranslation(text, lang, textMP));
    }
}