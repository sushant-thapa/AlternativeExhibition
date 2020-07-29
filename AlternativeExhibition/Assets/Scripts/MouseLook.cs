﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseLook : MonoBehaviour
{
	public float mouseSensitivity;	
	private float xRotation;
	public Transform playerBody;
    // Start is called before the first frame update
    void Start()
    {
        xRotation=0f;
    }

    // Update is called once per frame
    void Update()
    {

    	// RotateXAuto+=0.0001f;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity *Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);

         // this is because it makes rotation intuitive
        // giving a lock on the mouse
// 
        
        playerBody.Rotate(Vector3.up * mouseX); // Vector3.up is a shorthand for Vector3(0,1,0). so we are rotating by (0,mousex,0);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f); 
    }
}
