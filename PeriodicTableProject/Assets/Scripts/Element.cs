using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
	public int yearOfDiscovery;

	public GameObject bohrModelPrefab;

	public Canvas elementCanvas;

	private Vector3 originalPosition;
	private Vector3 originalScale;

	public bool isOpen = false;
	
	private void Start()
    {
		// Store the original position of the element
		elementCanvas.gameObject.SetActive(false);
		originalPosition = transform.position;
		originalScale = transform.localScale;
	}

	private void OnMouseDown()
    {
		if (isOpen == false)
		{
			OpenElementBox();
		}
		else if (isOpen == true)
        {
			CloseElementBox();
		}
	}

    private void OpenElementBox()
    {
		// Move the element closer to the player and scale it (adjust the position if needed)
		Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * 1f;
		targetPosition.y = -0.4f;
		float scaleFactor = 0.2f;

		float speed = 2f;

		while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
		{
			transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		}

		// Show  information on the UI canvas
		elementCanvas.gameObject.SetActive(true);
		elementCanvas.GetComponent<ElementInfoUI>().UpdateInfo(elementName, elementSymbol, description, atomicNumber, atomicWeight,
			meltingPoint, boilingPoint, discoveredBy, yearOfDiscovery);

		// Show 3D Bohr model
		Vector3 roundedPosition = new Vector3(
		Mathf.Floor(transform.position.x),
		Mathf.Floor(transform.position.y),
		Mathf.Floor(transform.position.z)
		);
        if (bohrModelPrefab != null)
        {
			Instantiate(bohrModelPrefab, roundedPosition + new Vector3(0f, 1f, -0.25f), Quaternion.identity).
			transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

			bohrModelPrefab.GetComponent<Animator>();
		}
        else
        {
			Debug.LogError("Bohr Model Prefab is not assigned.");
		}
		
		Collider[] allColliders = FindObjectsOfType<Collider>();

		// Disable each collider
		foreach (Collider collider in allColliders)
		{
			// Local scale of the collider's GameObject
			Vector3 colliderScale = collider.transform.localScale;

			// Check the y component of the scale
			if (colliderScale.y > 0.9f)
			{
				collider.enabled = false;
			}
			else
			{
				collider.enabled = true;
			}
		}

		isOpen = true;
	}

	public void CloseElementBox()
    {
		// Move the element back to its original position and scale it to the original size
		Vector3 targetPosition = originalPosition;
		Vector3 targetScale = originalScale;
		float speed = 2f;

		while (Vector3.Distance(transform.position, targetPosition) > 0.0f)
		{
			transform.localScale = targetScale;
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		}

		// Hide the UI canvas
		elementCanvas.gameObject.SetActive(false);

        // Destroy the 3D Bohr model
        if (bohrModelPrefab != null)
        {
			Destroy(GameObject.Find(bohrModelPrefab.name + "(Clone)"));
		}

		Collider[] allColliders = FindObjectsOfType<Collider>();

		// Enable each collider
		foreach (Collider collider in allColliders)
		{
			collider.enabled = true;
		}

		isOpen = false;
	}
}
