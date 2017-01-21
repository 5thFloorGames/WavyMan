using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrail : MonoBehaviour {

    public GameObject curveNodePrefad;
    private GameObject currentNode = null;
    private GameObject previousNode = null;
    public ParticleSystem particles;
    
	void Start () {
		particles.Stop();
	}

	void FixedUpdate () {
        if(Input.GetButton("Swing")) {
            if(!particles.isEmitting) {
                particles.Play();
            }
            previousNode = currentNode;
            
            currentNode = Instantiate(curveNodePrefad, transform.position, Quaternion.identity);
            currentNode.GetComponent<CurveNodeController>().SetPreviousNode(previousNode);
        } else if(particles.isEmitting){
		  particles.Stop();
        }
	}
}
