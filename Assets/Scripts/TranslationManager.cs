using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslationManager : Singleton<TranslationManager> {

    string text = "Hello";
    public InputField input;
    public Text downToggleLabel;
    List<Country> countries = new List<Country>();

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

    public void ReadInputText() {
        Debug.Log(input);
        if (input && input.text != "") {
            text = input.text;
            downToggleLabel.text = text;
        }
    }
}