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
	public Text yearOfDiscoveryText;

	public void UpdateInfo(string elementName, string elementSymbol, string description, int atomicNumber, double atomicWeight,
		double meltingPoint, double boilingPoint, string discoveredBy, int yearOfDiscovery)
    {
		elementNameText.text = elementName;
		elementSymbolText.text = elementSymbol;
		descriptionText.text = description;
		atomicNumberText.text = "Атомен номер: " + atomicNumber ;
		atomicWeightText.text = "Атомна маса: " + atomicWeight + " u";
		meltingPointText.text = "Температура на топене: " + meltingPoint + " °C";
		boilingPointText.text = "Температура на кипене: " + boilingPoint + " °C";
		discoveredByText.text = "Открит от: " + discoveredBy;
		yearOfDiscoveryText.text = "Година на откритие: " + yearOfDiscovery;

	}
}
