using UnityEngine;
using TMPro;

public class Country : MonoBehaviour  {

    string lang;
    readonly string fromLanguage = "en";
    public string toLanguage = "en";

    TextMeshPro textMP;

    private void Start()
    {
        lang = fromLanguage + '-' + toLanguage;
        textMP = GetComponent<TextMeshPro>();

        TranslationManager.Instance.Register(this);
        Translate(TranslationManager.Instance.GetText());
    }

    public Coroutine Translate(string text) {
        return StartCoroutine(TranslateAPI.GetTranslation(text, lang, textMP));
    }
}