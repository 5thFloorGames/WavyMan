using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

	public List<Color> colorList;
	public float colorLerpTime;

	Camera cam;
    Transform swordSprite;
	int currentColor;
	int maxColor;

	void Start () {
		cam = Camera.main.GetComponent<Camera>();
        swordSprite = GameObject.Find("Player").transform.FindChild("Sprites").transform.FindChild("Sword");
		currentColor = 0;
        StartCoroutine(LerpColors(colorList[currentColor], colorList[currentColor]));
        maxColor = colorList.Count-1;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			ChangeColor ();
		}
	}

	public void ChangeColor() {
		int nextColor = currentColor + 1;
		if (nextColor > maxColor) {
			nextColor = 0;
		}
        //print("changing color");
		StartCoroutine(LerpColors(colorList[currentColor], colorList[nextColor]));
		currentColor = nextColor;
	}

	IEnumerator LerpColors(Color startColor, Color endColor) {
		float ElapsedTime = 0.0f;
		while (ElapsedTime < colorLerpTime) {
			ElapsedTime += Time.deltaTime;
            swordSprite.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, (ElapsedTime / colorLerpTime));
            cam.backgroundColor = Color.Lerp(startColor, endColor, (ElapsedTime / colorLerpTime));
			yield return null;
		}
	}

}
