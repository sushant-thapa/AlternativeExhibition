using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
    
public class DownloadTexture : MonoBehaviour
{

    public GameObject Painting;
    private string URL;
    private bool isDownloadDone;
    private UnityWebRequest UWR;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetText());
    }   

    IEnumerator GetText() {

        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("action","designlist"));
        formData.Add(new MultipartFormFileSection("key", "0d37fe84c6eb4c4f92a51fe769faffed"));
        URL = "https://v3.explorug.com/appproviderv3.aspx";
        // UnityWebRequest UWR = UnityWebRequest.Get(URL);
        UWR = UnityWebRequest.Post(URL,formData);
        yield return UWR.SendWebRequest();
 
        if(UWR.isNetworkError || UWR.isHttpError) {
            Debug.Log(UWR.error);
        }
        else {
            // Show results as text

            print(JsonUtility.ToJson(UWR.downloadHandler.text)[0].GetType().GetProperties());


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
