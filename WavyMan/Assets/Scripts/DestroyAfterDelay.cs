using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour {

    public float delay = 1.0f;
    private AudioSource audioSource;
    private bool done = false;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
		//StartCoroutine(DestroyOnDelay());
	}
	
	// Update is called once per frame
	void Update () {
		if(!audioSource.isPlaying && !done){
            done = true;
            StartCoroutine(DestroyOnDelay());
        }
	}
    
    IEnumerator DestroyOnDelay(){
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
