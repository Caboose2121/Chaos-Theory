using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour
{
    public float movementSpeed = 5.0F;
    public float mouseSensitivity = 5.0F;
    float verticalRotation = 0;
    public float verticalRotLimit = 60.0F;
    public float jumpSpeed = 6.0F;
    float verticalVelocity = 0;
	public bool jumping = false;
    CharacterController characterController;

	public Camera mainCamera;

	void Start ()
	{
		characterController = GetComponent<CharacterController> ();
		if (characterController == null) {
			Debug.Log ("You got no goddamn controller.");
		}
	}







    void Update()
    {
        //Rotational Movement
        float rotX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotX, 0);
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotLimit, verticalRotLimit);
		mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //Ground Movement
        float lateralSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float longitudinalSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        Vector3 speed = new Vector3(longitudinalSpeed, verticalVelocity, lateralSpeed);
        speed = transform.rotation * speed;

		if (Input.GetButton ("sprint")) 
		{
			movementSpeed = 9.0F;
		} 
		else
		{
			movementSpeed = 5.0F;
		}

        //Jump Movement

		if (!characterController.isGrounded) 
		{
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
		}
        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpSpeed;
			jumping = true;
        }	

		else
		{
			jumping = false;
		}


		//Zoom feature when swapping states





	
        characterController.Move(speed * Time.deltaTime);
    }
}

