using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handlers : MonoBehaviour {

	public GameObject searchUp;
	public GameObject searchDown;
    public GameObject topNotice;
    public Sprite currentTranslationLang;
    public string currentTranslationLangText;

	// Use this for initialization
	void Start () {
        topNotice.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        TouchHandler();
    }

	public void toggleSearchVisibility() {
		if (searchUp.activeSelf) {
			searchUp.SetActive(false);
			searchDown.SetActive(true);
		} else {
			searchUp.SetActive(true);
			searchDown.SetActive(false);
		}
    }
	
    public void SubmitBtnHandler() {
        toggleSearchVisibility();
        TranslationManager.Instance.ReadInputText();
        TranslationManager.Instance.TranslateCountries();
    }

    private void TouchHandler()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit rayhit = new RaycastHit();
            if (Physics.Raycast(ray, out rayhit)) {
                var touchedObject = rayhit.collider.gameObject;
                TranslationManager.Instance.SetGoToPlay(touchedObject);
                
                currentTranslationLang = touchedObject.GetComponent<Country>().flag;
                currentTranslationLangText = touchedObject.GetComponent<Country>().visualToLanguage;
                topNotice.SetActive(true);
                
                TranslationManager.Instance.PlayTranslation();
            } else {
                TranslationManager.Instance.SetGoToPlay(null);
            }
        }
    }

}
