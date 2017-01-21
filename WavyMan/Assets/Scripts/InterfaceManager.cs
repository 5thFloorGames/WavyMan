using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour {
	public RectTransform wavyPosition;
	public Text wavyText;

	void Start () {
		
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.T)) {
			SpawnText ();
		}
	}

	public void SpawnText() {
		float horizontal = Random.Range (-100.0f, 100.0f);
		float vertical = Random.Range (-50.0f, 50.0f);
		wavyPosition.transform.localPosition = new Vector3 (horizontal, vertical, 0);
	}

	public void assignNewText () {

	}

}
