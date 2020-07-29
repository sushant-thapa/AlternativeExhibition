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
        URL = "https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/ART%20ACRYLIC/Cabalape.rendered.jpg";
        UWR = UnityWebRequestTexture.GetTexture(URL);
        UWR.SendWebRequest();

    }	

    // Update is called once per frame
    void Update()
    {
        	if( UWR.isDone) 
        		{
        			print("yes you may press space");
        			Painting.GetComponent<Renderer>().material.mainTexture = DownloadHandlerTexture.GetContent(UWR);
        		}
    }
}
