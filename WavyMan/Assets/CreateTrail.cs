using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrail : MonoBehaviour {

    public GameObject curveNodePrefad;
    private GameObject currentNode = null;
    private GameObject previousNode = null;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        previousNode = currentNode;
        
		currentNode = Instantiate(curveNodePrefad, transform.position, Quaternion.identity);
        currentNode.GetComponent<CurveNodeController>().SetPreviousNode(previousNode);
	}
}
