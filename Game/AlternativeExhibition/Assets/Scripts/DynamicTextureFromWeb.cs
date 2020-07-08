using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DynamicTextureFromWeb : MonoBehaviour
{

    Material m_Material;
	private UnityWebRequest UWR;
	void Start()
	{
		m_Material = GetComponent<Renderer>().material;
		UWR = UnityWebRequestTexture.GetTexture("https://png.pngtree.com/png-clipart/20190612/original/pngtree-the-red-letter-e-png-image_3396515.jpg");
		UWR.SendWebRequest();
	
	}

	void Update()
	{

		if(Input.GetKeyDown("space"))
		{
			print("hello");
		if (UWR.isDone)
		{
			m_Material.mainTexture = DownloadHandlerTexture.GetContent(UWR);
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
