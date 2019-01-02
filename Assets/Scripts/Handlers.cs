using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handlers : MonoBehaviour {

	public GameObject searchUp;
	public GameObject searchDown;
    public GameObject topNotice;
    public GameObject currentTranslationLang;
    public Text currentTranslationLangText;
    public Sprite contentSprite;
    public Sprite tappedContentSprite;

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
    public IEnumerator removeTappedState(Country tappedCountry) {
        yield return new WaitForSeconds(2);
        tappedCountry.textMP.color = new Color32(0, 0, 0, 255);
        tappedCountry.contentBubble.GetComponent<SpriteRenderer>().sprite = contentSprite;
        topNotice.SetActive(false);
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
                var tappedObject = rayhit.collider.gameObject;
                var tappedCountry = tappedObject.GetComponent<Country>();

                TranslationManager.Instance.SetGoToPlay(tappedObject);
                currentTranslationLang.GetComponent<Image>().sprite = tappedCountry.flag;
                currentTranslationLangText.text = tappedCountry.visualToLanguage;

                tappedCountry.textMP.color = new Color32(255, 255, 255, 255);
                tappedCountry.contentBubble.GetComponent<SpriteRenderer>().sprite = tappedContentSprite;
                topNotice.SetActive(true);
                TranslationManager.Instance.PlayTranslation();
								Handheld.Vibrate();

                StartCoroutine(removeTappedState(tappedCountry));
            } else {
                TranslationManager.Instance.SetGoToPlay(null);
            }
        }
    }

}
