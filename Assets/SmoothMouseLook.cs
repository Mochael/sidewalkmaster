using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class SmoothMouseLook : MonoBehaviour {
 
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
 
	public float minimumX = -60F;
	public float maximumX = 60F;
 
	public float minimumY = -1F;
	public float maximumY = 60F;
 
	float rotationX = 0F;
	float rotationY = 0F;
 
	private List<float> rotArrayX = new List<float>();
	float rotAverageX = 0F;	
 
	private List<float> rotArrayY = new List<float>();
	float rotAverageY = 0F;
 
	public float frameCounter = 20;
 
	Quaternion originalRotation;
 
	void Update ()
	{
		
		rotAverageY = 0f;

		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

		rotArrayY.Add(rotationY);

		if (rotArrayY.Count >= frameCounter) {
			rotArrayY.RemoveAt(0);
		}
		for(int j = 0; j < rotArrayY.Count; j++) {
			rotAverageY += rotArrayY[j];
		}
		rotAverageY /= rotArrayY.Count;

		rotAverageY = ClampAngle (rotAverageY, minimumY, maximumY);

		Quaternion yQuaternion = Quaternion.AngleAxis (rotAverageY, Vector3.left);
		transform.localRotation = originalRotation * yQuaternion;
		
	}
 
	void Start ()
	{		
                Rigidbody rb = GetComponent<Rigidbody>();	
		if (rb)
			rb.freezeRotation = true;
		originalRotation = transform.localRotation;
	}
 
	public static float ClampAngle (float angle, float min, float max)
	{
		angle = angle % 360;
		if ((angle >= -360F) && (angle <= 360F)) {
			if (angle < -360F) {
				angle += 360F;
			}
			if (angle > 360F) {
				angle -= 360F;
			}			
		}
		return Mathf.Clamp (angle, -1F, 75F);
	}
}