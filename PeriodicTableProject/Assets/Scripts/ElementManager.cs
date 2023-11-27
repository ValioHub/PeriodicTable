using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManager : MonoBehaviour {
	public GameObject elementPrefab;
	public Transform elementContainer;

	// Customize these variables based on the size of your periodic table
	public int rows = 7; // Number of rows
	public int columns = 18; // Number of columns

	public float spacing = 2f; // Spacing between elements

	// Use this for initialization
	void Start () {
		// Spawn elements in the scene
		SpawnElements();
	}

	void SpawnElements()
    {
		// Customize this method to spawn elements in a periodic table layout
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < columns; col++)
			{
				float x = col * spacing;
				float y = row * spacing;
				Vector3 position = new Vector3(x, 0f, y);
				GameObject element = Instantiate(elementPrefab, position, Quaternion.identity, elementContainer);
				// Customize additional properties of the element (e.g., name, description)
			}
		}
	}

	Vector3 GetElementPostion(int index)
    {
		// Customize this method to set the position of elements based on index
		float angle = (index / 10f) * 360f;
		float radius = 5f;
		Vector3 position = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * radius, 0f, Mathf.Sin(angle * Mathf.Deg2Rad) * radius);
		return position;
	}
}
