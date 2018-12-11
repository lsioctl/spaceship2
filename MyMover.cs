using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMover : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        // could get it also with 
        // rigidbody.velocity = transform.forward * speed
        rigidbody.velocity = new Vector3(0.0f, 0.0f, speed);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
