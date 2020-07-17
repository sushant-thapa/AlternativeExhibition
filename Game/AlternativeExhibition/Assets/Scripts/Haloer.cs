using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haloer : MonoBehaviour
{
	// private Renderer Rend;
	
	private GameObject childOfCurrent;
    // Start is called before the first frame update
    void Start()
    {
    	childOfCurrent = transform.GetChild(0).gameObject;
    	childOfCurrent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
    	childOfCurrent.SetActive(true);
    }
    void OnMouseExit()
    {
    	print("mouse has exited");
    	childOfCurrent.SetActive(false);
    }


}
