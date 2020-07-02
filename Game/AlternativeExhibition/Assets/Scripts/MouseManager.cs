
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MouseManager : MonoBehaviour
{
    public LayerMask clickableLayer;
    public EventVector3 onClickEnvironment; // So this is an instance of an event
    public Camera currentCamera;

    // The following are for cursors
    
    //public Texture2D pointer; // This is meant to be used to point at the floor to navigate
    //public Texture2D target; 	// This will be used to view paintings on the wall
    private RaycastHit hit;
   private void Update()
   {
      if(Physics.Raycast(currentCamera.ScreenPointToRay(Input.mousePosition), out hit,50, clickableLayer.value))
      {
         if (Input.GetMouseButtonDown(0)){
            onClickEnvironment.Invoke(hit.point); 
          }
      }

   
   }
}


[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>  { // I am not sure at the moment, but I think that there are multiple versions of 
                                                    // UnityEvent and UnityEventVector3 is one of them. so to simplify we just derived 
                                                    // EventVector3 from UnityEvent<Vector3> to make code more readable
}
