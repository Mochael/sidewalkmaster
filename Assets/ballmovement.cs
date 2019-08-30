using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballmovement : MonoBehaviour {
    public float zspeed = Random.value / 100;
    public float xforce;
    public float xvelocity = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        xvelocity += xforce * Time.deltaTime;
        // We could also have the balls curve and stuff by randomly changing the x and y coordinates
        //transform.Translate(shift, 0, -0.06f); 
        transform.position = new Vector3(transform.position.x + xvelocity * Time.deltaTime, transform.position.y, transform.position.z - zspeed);
        if (transform.position.z < -4)
        {
            Object.Destroy(gameObject);
            //Instantiate(Ball, transform.position, Quaternion.identity);
        }
	}
}
