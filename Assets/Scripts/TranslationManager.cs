using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslationManager : Singleton<TranslationManager> {

    string text = "Hello";
    public InputField input;
    public Text downToggleLabel;
    List<Country> countries = new List<Country>();

    private GameObject goToPlay;
    public AudioSource audioSource;

    public void Register(Country country) {
        input.text = text;
        downToggleLabel.text = text;
        countries.Add(country);
    }

    public void TranslateCountries() {
        countries.ForEach((Country country) => country.Translate(text));
    }

    public string GetText() {
        return text;
    }

    public void SetGoToPlay(GameObject goToPlay) {
        this.goToPlay = goToPlay;
    }

    public GameObject GetGoToPlay() {
        return goToPlay;
    }

    public void ReadInputText() {
        if (input && input.text != "") {
            text = input.text;
            downToggleLabel.text = text;
        }
    }

    public void PlayTranslation() {
        if (goToPlay.GetComponent<Country>().hl != "") {
            goToPlay.GetComponent<Country>().PlayAudio();
        }
    }

    public Coroutine Play(string text, string hl) {
        return StartCoroutine(TranslateAPI.GetAudio(audioSource, text, hl));
    }
}