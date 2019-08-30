using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	public GameObject Man;
    public float speedRatio;
	// Use this for initialization
	void Start () {
		Man = GameObject.Find("Character");
        //print(this.GetComponent<Collider>().transform.position);
        this.GetComponent<Collider>().transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float speed = speedRatio*Man.GetComponent<Animator>().GetFloat ("Blend");
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
		// If first crack is at position ___ then we need to spawn a new crack, that's how it must be done
		if (transform.position.z < -6) {
            Object.Destroy(gameObject);
		}
        //print(this.GetComponent<Collider>().transform.position);
        this.GetComponent<Collider>().transform.position = transform.position;
	}
}
