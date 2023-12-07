using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCloser : MonoBehaviour {
    Element element;
    public GameObject bohrModelPrefab;

    public GameObject Panel;
	public void ClosePanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
    public void MoveCubeToOriginalPosition()
    {
        // Find the cube GameObject using its tag
        element = GameObject.FindGameObjectWithTag("cube").GetComponent<Element>();
        element.CloseElementBox();
    }
}

