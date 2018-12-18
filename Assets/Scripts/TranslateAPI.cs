using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;


[Serializable]
class YandexResponse
{
    public int code;
    public string lang;
    public string[] text;
}

public static class TranslateAPI
{

    static public IEnumerator GetTranslation(string text, string lang, TextMeshPro textMP)
    {
        // var jsonString = "This is expected to be sent back as part of response body.";
        // byte[] byteData = System.Text.Encoding.ASCII.GetBytes(jsonString.ToCharArray());

        UnityWebRequest unityWebRequest = new UnityWebRequest("https://translate.yandex.net/api/v1.5/tr.json/translate" +
            "?key=" + WWW.EscapeURL("trnsl.1.1.20181212T172242Z.a4bf1dcd55b4bf6c.e73a26e97b9840343904454402d4288d108ac746") +
            "&text=" + WWW.EscapeURL(text) +
            "&lang=" + WWW.EscapeURL(lang)
        , "GET");
        DownloadHandlerBuffer downloadHandlerBuffer = new DownloadHandlerBuffer();

        unityWebRequest.downloadHandler = downloadHandlerBuffer;
        // unityWebRequest.uploadHandler = new UploadHandlerRaw(byteData);
        unityWebRequest.SetRequestHeader("Content-Type", "application/json");

        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
        {
            textMP.text = "ERROR";
            Debug.Log(unityWebRequest.error);
        }
        else
        {
            string response = unityWebRequest.downloadHandler.text;
            string textRes = JsonUtility.FromJson<YandexResponse>(response).text[0];
            textMP.text = textRes.ToLower();
            Debug.Log(response);
            Debug.Log(textRes);
        }
    }

    static public IEnumerator GetAudio(AudioSource audioSource, string text, string hl)
    {

        string url = "https://api.voicerss.org/" +
            "?key=" + "5fa428c283e34170aa6d7229debc13a8" +
            "&hl=" + WWW.EscapeURL(hl) +
            "&f=44khz_16bit_stereo" +
            "&src=" + WWW.EscapeURL(text);

        Debug.Log(url);

        WWW www = new WWW(url);

        yield return www;

        if (www.error != "")
        {
            Debug.Log("Error!" + url);
        }

        audioSource.clip = www.GetAudioClip(false, true, AudioType.MPEG);
        Debug.Log("clip is " + www.GetAudioClip(false, true, AudioType.MPEG));
        audioSource.Play();
    }
}