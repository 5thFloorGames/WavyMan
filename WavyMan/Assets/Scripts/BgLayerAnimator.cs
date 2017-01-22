using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLayerAnimator : MonoBehaviour {
	public float animationStartFrame;
	public float animationTotalFrames;
	Animator animator;

	void Start () {
		animator = gameObject.transform.GetChild (0).GetComponent<Animator>();
		animator.Play ("bglayeranim", 0 , animationStartFrame/animationTotalFrames);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
