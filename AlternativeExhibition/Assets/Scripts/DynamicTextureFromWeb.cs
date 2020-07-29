 
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
		print("done ");
		URLs = new string[] {
		
						"https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/Nemoxas.rendered.jpg",
						"https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/CLASSIC/Crorito.rendered.jpg",
						"https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/CLASSIC/Gurutent.rendered.jpg",
						"https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/CLASSIC/Reptyt%20Envipa.rendered.jpg",
						"https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/ELEMENTARY/Dinopa%20Dalog.rendered.jpg",
						"https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/ELEMENTARY/Venudrestre.rendered.jpg"
					};

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

		if(Input.GetKeyDown("a"))
		{
			print("A is pressed so the next line must be done");
			


			for (int i=0;i<6;i++){
				
				if (UWR[i].isDone)
				{
					print("i am inside the changer");
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