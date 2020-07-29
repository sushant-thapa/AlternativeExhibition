
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MouseManager : MonoBehaviour
{
    public LayerMask clickableLayer; // this determines where we can click
    public EventVector3 onClickEnvironment; // So this is an instance of an event. We have used this to move the NavMesh Agent
    public Camera currentCamera; // camera where we use to move the player

    // The following are for cursors
    public Texture2D pointer; // this is for the default
    public Texture2D target; // this is for a target. We can use this for painting for now
    public Texture2D sword; // 

    private RaycastHit hit;
    private void Update()
    {
      if(Physics.Raycast(currentCamera.ScreenPointToRay(Input.mousePosition), out hit,50, clickableLayer.value))
      {
        
        Cursor.SetCursor(target,new Vector2(16,16),CursorMode.Auto);

        if(hit.collider.gameObject.tag == "Painting")
        {
          Cursor.SetCursor(sword,new Vector2(16,16),CursorMode.Auto);
        }

        if (Input.GetMouseButtonDown(0)){
            onClickEnvironment.Invoke(hit.point); 
          }
    }
    else
    {
      Cursor.SetCursor(pointer,new Vector2(0,0),CursorMode.Auto);
    }
          
   
}
}


[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>  { // I am not sure at the moment, but I think that there are multiple versions of 
                                                    // UnityEvent and UnityEventVector3 is one of them. so to simplify we just derived 
                                                    // EventVector3 from UnityEvent<Vector3> to make code more readable
}
