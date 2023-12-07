﻿using System;
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
			meltingPoint, boilingPoint, discoveredBy, yearOfDiscovery);

		// Show 3D Bohr model
		Vector3 roundedPosition = new Vector3(
		Mathf.Floor(transform.position.x),
		Mathf.Floor(transform.position.y),
		Mathf.Floor(transform.position.z)
		);
		Instantiate(bohrModelPrefab, roundedPosition + new Vector3(0f, 0f, -4.25f), Quaternion.identity).
			transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		isOpen = true;
	}

	public void CloseElementBox()
    {
		// Move the element back to its original position
		Vector3 targetPosition = originalPosition;
		float speed = 2f;

		while (Vector3.Distance(transform.position, targetPosition) > 0.0f)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		}
		// Hide the UI canvas
		elementCanvas.gameObject.SetActive(false);

		// Destroy the 3D Bohr model
		Destroy(GameObject.Find(bohrModelPrefab.name + "(Clone)"));

		isOpen = false;
	}
}
