using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour 
{
	public string elementName;
	public string elementSymbol;
	public string description;
	public int atomicNumber;
	public double atomicWeight;
	public double meltingPoint;
	public double boilingPoint;
	public string discoveredBy;
	public GameObject bohrModelPrefab;
	public Canvas elementCanvas;

	private Vector3 originalPosition;
	private bool isOpen = false;
	
	private void Start()
    {
		// Store the original position of the element
		originalPosition = transform.position;
	}
	private void OnMouseDown()
    {
        if (!isOpen)
        {
			OpenElementBox();
        }
        else
        {
			CloseElementBox();
			float delay = 3.0f;
			Invoke("ReturnToOriginalPosition",delay);
		}
    }

    private void OpenElementBox()
    {
		// Check if elementCanvas is assigned
		if (elementCanvas == null)
		{
			Debug.LogError("Element Canvas is not assigned. Please assign it in the Inspector.");
			return;
		}
		ElementInfoUI elementInfoUI = elementCanvas.GetComponent<ElementInfoUI>();
		if (elementInfoUI == null)
		{
			Debug.LogError("ElementInfoUI script is not found on the Element Canvas. Please attach it.");
			return;
		}
		// Move the element closer to the player (you can adjust the position)
		Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * 5f;
		float speed = 2f;
		while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		}

		// Show  information on the UI canvas
		elementCanvas.gameObject.SetActive(true);
		elementCanvas.GetComponent<ElementInfoUI>().UpdateInfo(elementName, elementSymbol, description, atomicNumber, atomicWeight,
			meltingPoint, boilingPoint, discoveredBy);

		// Show 3D Bohr model
		Instantiate(bohrModelPrefab, transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);

		isOpen = true;
	}

	private void CloseElementBox()
    {
		// Move the element back to its original position
		Vector3 targetPosition = originalPosition;
		float speed = 2f;

		// Hide the UI canvas
		elementCanvas.gameObject.SetActive(false);

		// Destroy the 3D Bohr model
		Destroy(GameObject.Find(bohrModelPrefab.name + "(Clone)"));

		isOpen = false;
	}
}
