using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	public float rotationSpeed = 5f;

	// Update is called once per frame
	void Update () {
		// Rotate the camera based on mouse input
		float horizontalInput = Input.GetAxis("Mouse X");
		float verticalInput = Input.GetAxis("Mouse Y");

		transform.Rotate(Vector3.up, horizontalInput * rotationSpeed);
		transform.Rotate(Vector3.left, verticalInput * rotationSpeed);
	}
}
