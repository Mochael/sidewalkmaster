using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBall : MonoBehaviour {
	public float speed;
	public GameObject Ball;
	Vector3 ballStart = new Vector3(0, 1, 8); //-8.54
	// Use this for initialization
	void Start () {
		Instantiate(Ball, ballStart, Quaternion.identity, transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
