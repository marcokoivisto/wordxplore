using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslationManager : Singleton<TranslationManager> {

    string text = "Hello";
    public InputField input;
    List<Country> countries = new List<Country>();

    public void Register(Country country) {
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
        }
    }
}