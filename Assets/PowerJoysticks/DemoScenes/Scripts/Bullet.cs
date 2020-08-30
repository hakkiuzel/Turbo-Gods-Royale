using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Transform spawner;
	private Transform tr;
	private Rigidbody rb;

	// Use this for initialization
	void Awake () {
		tr = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody> ();
		tr.gameObject.SetActive (false);
	}

	void OnEnable () {
		tr.position = spawner.position;
		tr.rotation = spawner.rotation;
		rb.AddForce (tr.forward * 2000);
	}

	void OnDisable () {
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}

	void OnCollisionEnter (Collision collision) {
		tr.gameObject.SetActive (false);
	}
}
