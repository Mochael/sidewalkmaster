using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {
	
	public float speedCurrent;
	public float jumpHeight;
	public float gravity;
	Animator animator;
	public CharacterController controller;
    public Vector3 movement= Vector3.zero;
	public float currentHeight = 0;
	// Use this for initialization
	void Start () {
		// Set movement speed to .2 or something and then start going.
		animator = GetComponent<Animator> ();
		animator.SetFloat ("Blend", .2f);
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		print(controller.isGrounded);
		if (controller.isGrounded == false) {
			//print ("WE ARE AIRBORN BABY");
			currentHeight -= .1f;
			movement.y += gravity * Time.deltaTime;
			controller.Move(movement * Time.deltaTime);
		}
		speedCurrent = animator.GetFloat ("Blend");
// How should the game work? If you let go do you decelerate or just maintain speed and use two fingers to slow down?
		//if (controller.isGrounded) {
		if (Input.touches.Length == 1) {
			if (speedCurrent < 1) {
				speedCurrent = speedCurrent + .04f;
			}
		} else if (Input.touchCount == 2) {
			if (speedCurrent > .1) {
				speedCurrent = speedCurrent - .04f;
			}
		}
		if (Input.GetKey("up")) {
			if (speedCurrent < 1) {
				speedCurrent = speedCurrent + .04f;
			}
		} else if (Input.GetKey("down")) {
			if (speedCurrent > .1) {
				speedCurrent = speedCurrent - .04f;
			}
		}
		animator.SetFloat ("Blend", speedCurrent);

		if (Input.touchCount == 3){
			Jump ();
		// Check if iPhone is being touched and then update the movement speed accordingly.
		}
		if (Input.GetKey("space")){
			Jump ();
			// Check if iPhone is being touched and then update the movement speed accordingly.
		}
}

	void Jump(){
		if (controller.isGrounded ) {
			currentHeight = 1;
			movement.y = 1;
			// Mathf.Sqrt (-2 * gravity * jumpHeight);
			controller.Move (movement*Time.deltaTime);
		}
	}
}