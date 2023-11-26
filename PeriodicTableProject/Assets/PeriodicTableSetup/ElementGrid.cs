using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementGrid : MonoBehaviour
{
	public GameObject elementPrefab;
	public int rows = 7;
	public int columns = 18;
	// Use this for initialization
	void Start()
	{
		GenerateGrid();
	}
	void GenerateGrid()
	{
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < columns; col++)
			{
				// Instantiate ElementPrefab at a position based on row and column
				GameObject element = Instantiate(elementPrefab, new Vector3(col * 2, -row * 2, 0), Quaternion.identity);
				element.transform.SetParent(transform); // Set the element as a child of PeriodicTable

				// Add a script to handle element click
				element.AddComponent<ElementClickHandler>();
			}
		}
	}
	// Update is called once per frame
	void Update()
	{

	}
}