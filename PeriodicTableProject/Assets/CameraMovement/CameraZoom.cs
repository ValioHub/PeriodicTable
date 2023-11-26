using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
	public float zoomSpeed = 5f;
	public float minZoom = 2f;
	public float maxZoom = 10f;

	// Update is called once per frame
	void Update () 
	{
		// Zoom in with the mouse scroll wheel
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scroll * zoomSpeed, minZoom, maxZoom);
	}
}
