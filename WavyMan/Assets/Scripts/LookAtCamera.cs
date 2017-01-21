using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {
	public GameObject camera;

	void Start () {
		
	}

	void Update () {
		transform.LookAt (2*transform.position - camera.transform.position, Vector3.up);
	}
}
