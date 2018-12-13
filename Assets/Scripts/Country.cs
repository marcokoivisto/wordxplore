using UnityEngine;
using TMPro;

public class Country : MonoBehaviour  {

    string lang;
    readonly string fromLanguage = "en";
    public string toLanguage = "en";
    public Camera cameraToLookAt;

    TextMeshPro textMP;

    private void Start()
    {
        lang = fromLanguage + '-' + toLanguage;
        textMP = GetComponent<TextMeshPro>();

        TranslationManager.Instance.Register(this);
        Translate(TranslationManager.Instance.GetText());
    }

    void Update () {
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt( cameraToLookAt.transform.position - v ); 
        transform.Rotate(0,180,0);
    }

    public Coroutine Translate(string text) {
        return StartCoroutine(TranslateAPI.GetTranslation(text, lang, textMP));
    }
}