using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TMPNumberToString : MonoBehaviour
{
	private TextMeshProUGUI textmesh;
	[SerializeField] private string suffix;
	[SerializeField] [Range(0, 10)] private int decimals = 2;
	private void Awake()
	{
		if (!TryGetComponent(out textmesh))
			Debug.LogWarning("Missing component on object", gameObject);
		InputFloat(0f);
	}
	public void InputFloat(float value)
	{
		textmesh.text = $"{FixedNumberOfDigits(value, decimals)}{suffix}";
	}

	private float SignificantDigits(float value, int digits)
	{
		float power = Mathf.Pow(10f, digits);
		return ((float)((int)(value * power))) / power;
	}

	private string FixedNumberOfDigits(float value, int digits)
	{
		string converted = SignificantDigits(value, digits).ToString();

		string[] split = converted.Split(CurrentDelimiter);
		string decimalString = split.Length > 1 ? split[1] : "";
		while (decimalString.Length < digits)
			decimalString += "0";
		string separator = digits > 0 ? CurrentDelimiter.ToString() : "";
		return $"{split[0]}{separator}{decimalString}";
	}

	private char currentDelimiter;
	private char CurrentDelimiter
	{
		get
		{
			if (!char.IsSymbol(currentDelimiter))
				currentDelimiter = (1.1f).ToString().Contains(",") ? ',' : '.';
			return currentDelimiter;
		}
	}
}
