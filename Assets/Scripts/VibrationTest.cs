using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RDG;

public class VibrationTest : MonoBehaviour
{
	[Range(-1, 255)]
	[SerializeField] private int amplitude = -1;
    void Update()
    {
		if (Input.touchCount > 1)
			Vibration.Vibrate(1, amplitude, true);
    }
}
