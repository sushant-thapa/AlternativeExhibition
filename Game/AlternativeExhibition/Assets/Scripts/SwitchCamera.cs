using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
	public Camera PlayerCam;
    public Camera CameraA;
    public Camera CameraS;
    public Camera CameraD;
    public Camera CameraF;
    public Camera CameraG;
    
    // Update is called once per frame
    void Update()
    {
    		
        if (Input.GetKeyDown("space"))
        {
        	print("space");
        	PlayerCam.enabled = true;
        	CameraA.enabled = false;
        	CameraS.enabled=false;
        	CameraD.enabled=false;
        	CameraF.enabled=false;
        	CameraG.enabled=false;
    
        }
        
         if (Input.GetKeyDown("a"))
        {
        	print("a");
        	PlayerCam.enabled = false;
			CameraA.enabled=true;
        	CameraS.enabled=false;
        	CameraD.enabled=false;
        	CameraF.enabled=false;
        	CameraG.enabled=false;
    
        }
        
         if (Input.GetKeyDown("s"))
        {
        	print("s");
        	PlayerCam.enabled = false;
        	CameraA.enabled = false;
        	CameraS.enabled=true;
        	CameraD.enabled=false;
        	CameraF.enabled=false;
        	CameraG.enabled=false;
    
        }
        
         if (Input.GetKeyDown("d"))
        {
        	print("d");
        	PlayerCam.enabled = false;
        	CameraA.enabled = false;
        	CameraS.enabled=false;
        	CameraD.enabled=true;
        	CameraF.enabled=false;
        	CameraG.enabled=false;
    
        }
        
         if (Input.GetKeyDown("f"))
        {
        	PlayerCam.enabled = false;
        	CameraA.enabled = false;
        	CameraS.enabled=false;
        	CameraD.enabled=false;
        	CameraF.enabled=true;
        	CameraG.enabled=false;
    
        }
         if (Input.GetKeyDown("g"))
         {
         	print("g");
         	PlayerCam.enabled = false;
        	CameraA.enabled = false;
        	CameraS.enabled=false;
        	CameraD.enabled=false;
        	CameraF.enabled=false;
        	CameraG.enabled=true;
        }
    
         }
    }
