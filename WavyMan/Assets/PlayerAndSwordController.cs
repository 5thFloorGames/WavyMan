using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndSwordController : MonoBehaviour {

    private Rigidbody bod;
    public GameObject Sword;
    private GameObject currentNode = null;
    private GameObject previousNode = null;
    public GameObject curveNodePrefab;

    void Awake()
    {
        bod = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        HandleInput();
        
		previousNode = currentNode;
        currentNode = Instantiate(curveNodePrefab, transform.position, Quaternion.identity);
        currentNode.GetComponent<CurveNodeController>().SetPreviousNode(previousNode);
	}
    
    void HandleInput(){
        bod.AddForce(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        
        bod.AddForce(-transform.position.x, 0, 0);
        bod.AddForce(0, -transform.position.y , 0);
        
        float swordHorizontal = Input.GetAxis("SwordHorizontal");
        float swordVertical = Input.GetAxis("SwordVertical");
        
        if(Sword != null){
            Sword.transform.localPosition = new Vector3((swordHorizontal) * 1.5f,(swordVertical) * 1.5f, 0);
            if(swordVertical < 0){
                Sword.transform.rotation = Quaternion.Euler(0,0, 270 + swordHorizontal * 90);
            } else {
                Sword.transform.rotation = Quaternion.Euler(0,0, 90 + swordHorizontal * -90);
            }
        }
    }
}
