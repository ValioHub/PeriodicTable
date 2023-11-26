using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementInformation : MonoBehaviour {

	public Text elementNameText;
	public Text atomicNumberText;
	public Text atomicMassText;

	public void DisplayElementInformation(string elementName,string atomicNumber,string atomicMass)
    {
		elementNameText.text = "Element: " + elementName;
		atomicNumberText.text = "Atomic Number: " + atomicNumber;
		atomicMassText.text = "Atomic Mass: " + atomicMass;
    }
}
