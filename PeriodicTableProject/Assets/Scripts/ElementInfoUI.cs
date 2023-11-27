using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementInfoUI : MonoBehaviour 
{
	public Text elementNameText;
	public Text elementSymbolText;
	public Text descriptionText;
	public Text atomicNumberText;
	public Text atomicWeightText;
	public Text meltingPointText;
	public Text boilingPointText;
	public Text discoveredByText;

	public void UpdateInfo(string elementName, string elementSymbol, string description, int atomicNumber, double atomicWeight,
		double meltingPoint, double boilingPoint, string discoveredBy)
    {
		elementNameText.text = elementName;
		elementSymbolText.text = elementSymbol;
		descriptionText.text = description;
		atomicNumberText.text = "Atomic Number:" + atomicNumber;
		atomicWeightText.text = "Atomic Weight: " + atomicWeight;
		meltingPointText.text = "Melting Poing: " + meltingPoint;
		boilingPointText.text = "Boiling Point: " + boilingPoint;
		discoveredByText.text = "Discovered By: " + discoveredBy;

	}
}
