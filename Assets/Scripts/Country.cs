﻿using UnityEngine;
using TMPro;

public class Country : MonoBehaviour  {

    string lang;
    readonly string fromLanguage = "en";
    public string toLanguage = "en";
    public string visualToLanguage = "English";
    public string hl = "en-gb";

    public Sprite flag = null;

    public Camera cameraToLookAt;

    public TextMeshPro textMP;
    public GameObject contentBubble;

    private void Start()
    {
        lang = fromLanguage + '-' + toLanguage;
        textMP = GetComponent<TextMeshPro>();

        TranslationManager.Instance.Register(this);
        Translate(TranslationManager.Instance.GetText());
    }

    void Update () {
        FaceCamera();
    }

    private void FaceCamera() {
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(cameraToLookAt.transform.position - v);
        transform.Rotate(0, 180, 0);
    }

    public Coroutine Translate(string text) {
        return StartCoroutine(TranslateAPI.GetTranslation(text, lang, textMP));
    }

    public void PlayAudio() {
        TranslationManager.Instance.Play(textMP.text, hl);
    }
}