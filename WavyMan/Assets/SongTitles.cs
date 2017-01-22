using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongTitles : MonoBehaviour {

    public Sprite[] songTitles;
    private Image image;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
		StartCoroutine(NewTitle());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    IEnumerator FadeOut(){
        yield return new WaitForSeconds(2);
        while(image.color.a > 0){
            image.color = new Color(image.color.r, image.color.b, image.color.g, image.color.a - Time.deltaTime / 3);
            
            yield return null;
        }
    }
    
    IEnumerator NewTitle(){
        while(true){
            image.sprite = songTitles[Random.Range(0, songTitles.Length)];
            image.color = new Color(image.color.r, image.color.b, image.color.g, 1);
            StartCoroutine(FadeOut());
            yield return new WaitForSeconds(32);
        }
    }
}
