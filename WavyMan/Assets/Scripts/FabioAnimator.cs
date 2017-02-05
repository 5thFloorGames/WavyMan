using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabioAnimator : MonoBehaviour {

	Animator armAnimator;
	Animator swordAnimator;
	float num;
    float previousNum;

	void Start () {
        previousNum = 9;
		armAnimator = transform.FindChild ("Arms").GetComponent<Animator> ();
		swordAnimator = transform.FindChild ("Sword").GetComponent<Animator>();
        swordAnimator.SetBool("1", true);
		num = 0;
		ArmPosition (0);
	}

	void Update () {
	}

	public void ArmPosition(float positionNum) {
        if (previousNum == positionNum) {
            return;
        }
        previousNum = positionNum;
		armAnimator.Play("wavymanArms", 0, (positionNum - 1.0f)/8.0f);

        for (int i = 1; i <= 8; i++) {
            if (i == (int)positionNum) {
                swordAnimator.SetBool("" + i, true);
            } else {
                swordAnimator.SetBool("" + i, false);
            }
        }
		//swordAnimator.Play("sword", 0, positionNum/8.0f);
	}
}
