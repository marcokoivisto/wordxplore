using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handlers : MonoBehaviour {

	public GameObject searchUp;
	public GameObject searchDown;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void toggleSearchHello() {
		if (searchUp.activeSelf) {
			searchUp.SetActive(false);
			searchDown.SetActive(true);
		} else {
			searchUp.SetActive(true);
			searchDown.SetActive(false);
		}
    }
	
    public void SubmitBtnHandler() {
		toggleSearchHello();
        TranslationManager.Instance.ReadInputText();
        TranslationManager.Instance.TranslateCountries();
	}

}
