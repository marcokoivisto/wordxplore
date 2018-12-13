using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handlers : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SubmitBtnHandler() {
        TranslationManager.Instance.ReadInputText();
        TranslationManager.Instance.TranslateCountries();
    }

}
