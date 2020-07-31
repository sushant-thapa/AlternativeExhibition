 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DynamicTextureFromWeb : MonoBehaviour
{

    public GameObject[] Painting;
	private UnityWebRequest[] UWR;
	private string[] URLs;
	private bool isDownloadDone;
	void Start()
	{
		URLs = new string[] {"https://pkperfumes.com/wp-content/uploads/2016/05/Starry-Night-Van-Gogh-retouched-medium.jpg",
						"https://s4.scoopwhoop.com/anj/paintings/778914987.jpg",
						"https://media.overstockart.com/optimized/cache/data/product_images/VE2140-1000x1000.jpg",
						"https://manjitkumar.files.wordpress.com/2011/05/feynman-3001.jpg",
						"https://hexagongallery.com/wp-content/uploads/2017/01/GWB_SIGNED_RED-717x1000.jpg",
						"http://3.bp.blogspot.com/-wgkAKkeNgXk/T9ky-RubhbI/AAAAAAAAC3E/-F6-6hfFQm0/s1600/The+Beatles+-+Abbey+Road.jpg"};

		UWR = new UnityWebRequest[6];

		for (int i =0;i<URLs.Length;i++){
			UWR[i] = UnityWebRequestTexture.GetTexture(URLs[i]);
		}

for (int i =0;i<URLs.Length;i++){
			UWR[i].SendWebRequest();
		}
		
		
	
	}

	void Update()
	{
		isDownloadDone = true;
		for (int i=0;i<6;i++)
		{
			isDownloadDone = UWR[i].isDone & isDownloadDone;
		}

		if (isDownloadDone)
		{
			print("downloaded");
		}

		if(Input.GetKeyDown("space"))
		{
			print("hello");

			for (int i=0;i<6;i++){
				
				if (UWR[i].isDone)
				{
					Painting[i].GetComponent<Renderer>().material.mainTexture = DownloadHandlerTexture.GetContent(UWR[i]);
				}	
			}
		}
	}
	

    // public string url = ""; 

    // IEnumerator Start()
    // {
    //     using (WWW www = new WWW(url))
    //     {
        	
    //         yield return www;
    //         Renderer renderer = GetComponent<Renderer>();
    //         renderer.material.mainTexture = www.texture;
    //     }
    // }
}