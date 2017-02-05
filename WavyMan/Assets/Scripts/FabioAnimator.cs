using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabioAnimator : MonoBehaviour {

	Animator armAnimator;
	Animator swordAnimator;
	float num;

	void Start () {
		armAnimator = transform.FindChild ("Arms").GetComponent<Animator> ();
		swordAnimator = transform.FindChild ("Sword").GetComponent<Animator>();
		num = 0;
		ArmPosition (0);
	}

	void Update () {
	}

	public void ArmPosition(float positionNum) {
		armAnimator.Play("wavymanArms", 0, positionNum/8.0f);
		swordAnimator.Play("sword", 0, positionNum/8.0f);
	}
}
