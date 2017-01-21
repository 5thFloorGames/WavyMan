using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrail : MonoBehaviour {

    public GameObject curveNodePrefad;
    private GameObject currentNode = null;
    private GameObject previousNode = null;
    public ParticleSystem particles;
    
	// Use this for initialization
	void Start () {
		particles.Pause();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Input.GetButton("Swing")) {
            if(!particles.isEmitting) {
                particles.Play();
            }
            previousNode = currentNode;
            
            currentNode = Instantiate(curveNodePrefad, transform.position, Quaternion.identity);
            currentNode.GetComponent<CurveNodeController>().SetPreviousNode(previousNode);
        } else if(particles.isEmitting){
		  particles.Pause();
        }
	}
}
