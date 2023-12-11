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
		// elementNameText
		elementNameText.text = elementName;

		// elementSymbolText
		elementSymbolText.text = elementSymbol;

		// descriptionText
		descriptionText.text = description;

		// atomicNumberText
		atomicNumberText.text = "Атомен номер: " + atomicNumber ;

		// atomicWeightText
		atomicWeightText.text = "Атомна маса: " + atomicWeight + " u";

		// meltingPointText
		if (meltingPoint != 0)
		{
			meltingPointText.text = "Температура на топене: " + meltingPoint + " °C";
			meltingPointText.gameObject.SetActive(true);
		}
		else
		{
			meltingPointText.gameObject.SetActive(false);
		}

		// boilingPointText
		if (boilingPoint != 0)
		{
			boilingPointText.text = "Температура на кипене: " + boilingPoint + " °C";
			boilingPointText.gameObject.SetActive(true);
		}
		else
		{
			boilingPointText.gameObject.SetActive(false);
		}

		// discoveredByText
		if (!string.IsNullOrEmpty(discoveredBy))
        {
			discoveredByText.text = "Открит от: " + discoveredBy;
			discoveredByText.gameObject.SetActive(true);
		}
        else
        {
			discoveredByText.gameObject.SetActive(false);
		}

		// yearOfDiscoveryText
		if (yearOfDiscovery != 0)
        {
			yearOfDiscoveryText.text = "Година на откритие: " + yearOfDiscovery;
			yearOfDiscoveryText.gameObject.SetActive(true);
		}
		else
		{
			yearOfDiscoveryText.gameObject.SetActive(false);
		}
	}
}
