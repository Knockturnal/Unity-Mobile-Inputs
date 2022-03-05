using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Multitouch : MonoBehaviour
{
	[SerializeField] private int touchIndex;
	private RectTransform rect;

	private void Awake()
	{
		rect = GetComponent<RectTransform>();
	}

	private void Update()
	{
		if(Input.touchCount > touchIndex)
			rect.position = Input.GetTouch(touchIndex).position;
	}
}
