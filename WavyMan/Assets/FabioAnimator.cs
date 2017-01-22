using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabioAnimator : MonoBehaviour {

	Animator armAnimator;
	float num;

	void Start () {
		armAnimator = transform.FindChild ("Arms").GetComponent<Animator> ();
		num = 0;
		ArmPosition (0);
	}

	void Update () {
	}

	public void ArmPosition(float positionNum) {
		armAnimator.Play("wavymanArms", 0, positionNum/8.0f);

	}
}
