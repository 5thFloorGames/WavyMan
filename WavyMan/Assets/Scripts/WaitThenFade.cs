using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitThenFade : MonoBehaviour {

	private Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		StartCoroutine(WaitFade());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator WaitFade (){
		yield return new WaitForSeconds(5);
		Color oldColor = image.color;
		while(image.color.a > 0){
			image.color = new Color(oldColor.r, oldColor.b, oldColor.g, image.color.a - 0.01f);
			yield return null;
		}
	}
}
