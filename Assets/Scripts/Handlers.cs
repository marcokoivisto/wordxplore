using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handlers : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TouchHandler();
    }

    public void SubmitBtnHandler() {
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
                TranslationManager.Instance.SetGoToPlay(rayhit.collider.gameObject);
                TranslationManager.Instance.PlayTranslation();
            } else {
                TranslationManager.Instance.SetGoToPlay(null);
            }
        }
    }

}
