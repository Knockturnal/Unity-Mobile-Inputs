using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
	//	To zero the gyro
	private Quaternion offset = Quaternion.identity;
	public bool enableUnityRemote = true;

	private void Start()
	{
		//	Alert if gyroscope is not enabled, except if we specifically want to use Remote
		if (SystemInfo.supportsGyroscope || enableUnityRemote)
			Input.gyro.enabled = true;
		else
			Debug.LogWarning("No gyroscope dected on device");
	}

	void Update()
    {
		transform.localRotation = GyroToUnity(offset * Input.gyro.attitude);
	}

	private static Quaternion GyroToUnity(Quaternion q)
	{
		//	Convert from right to left handed coords
		return new Quaternion(q.x, q.y, -q.z, -q.w);
	}

	public void ResetGyro()
	{
		//	By getting the inverse of the current gyro and "adding" (actually multiplication because Quaternions...) it to the input in Update(), they cancel out
		offset = Quaternion.Inverse(Input.gyro.attitude);
	}
}
