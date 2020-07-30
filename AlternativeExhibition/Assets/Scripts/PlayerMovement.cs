using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	private CharacterController controller; 
	public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
     controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {


        float x = Input.GetAxis("Horizontal"); // here Input.GetAxis("Horizontal") gives us a 1 when we firmly hold down W and gives -1 when we hold S
        									  //  it gives a value of magnitude less than one when pressed for a shorter time
        

        float z = Input.GetAxis("Vertical"); // here Input.GetAxis("Vertical") gives us a 1 when we hold down W and -1 for S
        									// magnitude of less than one is given if key is pressed for shorter duration 
        print(z);


        // transform.right takes the direction the user is facing which we multiply by x
        // similarly transform.forward is simply taking the direction which the user sees as forward and multiplies by z 
        Vector3 move = transform.right * x + transform.forward * z;
        
        // Time.deltaTime makes the movement frame rate independent re
        controller.Move(move*speed*Time.deltaTime);
    }
}
