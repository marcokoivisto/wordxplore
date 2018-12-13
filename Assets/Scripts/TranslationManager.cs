using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslationManager : Singleton<TranslationManager> {

    string text = "Hello";
    public InputField input;
    List<Country> countries = new List<Country>();

    private GameObject goToPlay;
    public AudioSource audioSource;

    public void Register(Country country) {
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
        Debug.Log(input);
        if (input && input.text != "") {
            text = input.text;
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