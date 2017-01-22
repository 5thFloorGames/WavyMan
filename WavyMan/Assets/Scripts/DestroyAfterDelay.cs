using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour {

    public float delay = 1.0f;

    private bool done = false;

	// Use this for initialization
	void Start () {
		StartCoroutine(DestroyOnDelay());
	}
	
	// Update is called once per frame
	void Update () {
	}
    
    IEnumerator DestroyOnDelay(){
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
