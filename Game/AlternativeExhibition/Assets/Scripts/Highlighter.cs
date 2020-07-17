using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
	private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    private void OnMouseEnter()
    {
    	rend.material.color = Color.yellow;
    	print("mouse has entered");

    }
    private void OnMouseOver()
    
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.OpenURL("https://explorug.net");
        }
        
    }

    private void OnMouseExit()
    {
    	rend.material.color = Color.white;
    }

    private void Update()
    {
        
    }
}
