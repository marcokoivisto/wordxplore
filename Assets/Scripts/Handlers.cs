using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handlers : MonoBehaviour {

	public GameObject searchUp;
	public GameObject searchDown;
    public GameObject topNotice;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TouchHandler();
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

    private void TouchHandler()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit rayhit = new RaycastHit();
            if (Physics.Raycast(ray, out rayhit)) {
                topNotice.SetActive(true);
                TranslationManager.Instance.SetGoToPlay(rayhit.collider.gameObject);
                TranslationManager.Instance.PlayTranslation();
                //topNotice.SetActive(false);
            } else {
                TranslationManager.Instance.SetGoToPlay(null);
            }
        }
    }

}
