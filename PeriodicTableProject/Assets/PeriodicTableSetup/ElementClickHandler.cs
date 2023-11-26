using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementClickHandler : MonoBehaviour
{
	public string elementName;
	public string atomicNumber;
	public string atomicMass;
	public GameObject elementModelPrefab; // Reference to the 3D model prefab
	// Use this for initialization
	void Start () 
	{
		Button button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
	}
	
	void OnClick()
    {
		Debug.Log("Element clicked! Implement zoom and information display here.");

		// Zoom in the camera (assuming the CameraZoom script is attached to the main camera)
		Camera.main.GetComponent<CameraZoom>().enabled = true;

		// Display information on the UI panel
		ElementInformation infoPanel = GameObject.Find("InformationPanel").GetComponent<ElementInformation>();
		infoPanel.DisplayElementInformation(elementName, atomicNumber, atomicMass);

		// Load and display the 3D model
		Instantiate(elementModelPrefab, transform.position, Quaternion.identity);
	}
}
