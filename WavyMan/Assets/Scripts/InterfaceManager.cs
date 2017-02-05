﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour {

    private string[] texts = {
        "Ooh, wavy man", "Heavenly", "You've got it", "Amazing", "Faster!", "Groovy", "Juicy", "Keep going",
        "Nice", "Oh boy", "Oh boy!" , "Oh God!", "Oh wow", "So good", "Wavy", "Mmmm, Wavyman", "Oh, Wavyman",
        "Finish her"
        };
    public Dictionary<string, AudioClip> textToSound;
    
    private GameObject wavyTextPrefab;
    
    public Fabric.AudioComponent[] DialogueSound;

    private GameController controller;
    
    private int i = 0;

	void Start () {
        controller = FindObjectOfType<GameController>();
		textToSound = new Dictionary<string, AudioClip>();
        textToSound.Add(texts[0], Resources.Load<AudioClip>("Audio/Wavyman 2"));
        textToSound.Add(texts[1], Resources.Load<AudioClip>("Audio/Heavenly"));
        textToSound.Add(texts[2], Resources.Load<AudioClip>("Audio/You've got it"));
        textToSound.Add(texts[3], Resources.Load<AudioClip>("Audio/Amazing"));
        textToSound.Add(texts[4], Resources.Load<AudioClip>("Audio/Faster!"));
        textToSound.Add(texts[5], Resources.Load<AudioClip>("Audio/Groovy"));
        textToSound.Add(texts[6], Resources.Load<AudioClip>("Audio/Juicy"));
        textToSound.Add(texts[7], Resources.Load<AudioClip>("Audio/Keep Going")); 
        textToSound.Add(texts[8], Resources.Load<AudioClip>("Audio/Nice"));      
        textToSound.Add(texts[9], Resources.Load<AudioClip>("Audio/Oh boy"));   
        textToSound.Add(texts[10], Resources.Load<AudioClip>("Audio/Oh boy!"));    
        textToSound.Add(texts[11], Resources.Load<AudioClip>("Audio/Oh God!"));
        textToSound.Add(texts[12], Resources.Load<AudioClip>("Audio/Oh wow"));        
        textToSound.Add(texts[13], Resources.Load<AudioClip>("Audio/So Good"));                                                                                
        textToSound.Add(texts[14], Resources.Load<AudioClip>("Audio/Wavy"));                                                                                                    
        textToSound.Add(texts[15], Resources.Load<AudioClip>("Audio/Wavyman 1"));                                                                                                                        
        textToSound.Add(texts[16], Resources.Load<AudioClip>("Audio/Wavyman 3"));                                                                                                                        
        textToSound.Add(texts[17], Resources.Load<AudioClip>("Audio/Finish Her!"));                                                                                                                        

        wavyTextPrefab = Resources.Load<GameObject>("Wavy Text");
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.T)) {
			SpawnText ();
		}
	}

	public void SpawnText() {
        string textThing = texts[Random.Range(0, texts.Length - 1)];
        if(controller.getLevel() > 3){
            textThing = texts[Random.Range(0, texts.Length)];
        }
        DialogueSound[i++ % 2].AudioClip = textToSound[textThing];
        GameObject newText = Instantiate(wavyTextPrefab, transform);
		float horizontal = Random.Range (-200.0f, 200.0f);
		float vertical = Random.Range (-100.0f, 100.0f);
        float rotation = Random.Range(-20.0f, 20.0f);
        newText.GetComponent<RectTransform>().transform.localPosition = new Vector3 (horizontal, vertical, 0);
        newText.GetComponent<RectTransform>().transform.localRotation = Quaternion.Euler(new Vector3 (0, 0, rotation));
        newText.GetComponent<Text>().text = textThing;
	}

}
