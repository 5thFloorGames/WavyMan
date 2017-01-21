using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour {
    private string[] texts = {"Ooh, wavy man", "Heavenly", "You've got it"};
    public Dictionary<string, AudioClip> textToSound;
    
    private GameObject wavyTextPrefab;

	void Start () {
		textToSound = new Dictionary<string, AudioClip>();
        textToSound.Add(texts[0], Resources.Load<AudioClip>("Audio/Wavyman 2"));
        textToSound.Add(texts[1], Resources.Load<AudioClip>("Audio/Heavenly"));
        textToSound.Add(texts[2], Resources.Load<AudioClip>("Audio/You've got it"));
        wavyTextPrefab = Resources.Load<GameObject>("Wavy Text");
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.T)) {
			SpawnText ();
		}
	}

	public void SpawnText() {
        GameObject newText = Instantiate(wavyTextPrefab, transform);
		float horizontal = Random.Range (-100.0f, 100.0f);
		float vertical = Random.Range (-50.0f, 50.0f);
		newText.GetComponent<RectTransform>().transform.localPosition = new Vector3 (horizontal, vertical, 0);
        string textThing = texts[Random.Range(0, texts.Length)];
        newText.GetComponent<Text>().text = textThing;
        AudioSource newSource = newText.GetComponent<AudioSource>();
        newSource.clip = textToSound[textThing];
        newSource.Play();
	}

}
