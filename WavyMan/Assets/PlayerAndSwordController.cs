using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndSwordController : MonoBehaviour {

    private Rigidbody bod;
    public GameObject Sword;
    private GameObject currentNode = null;
    private GameObject previousNode = null;
    public GameObject curveNodePrefab;
    
    public float particleInterval = 0.1f;

    void Awake()
    {
        bod = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnParticle());
	}
    
    IEnumerator SpawnParticle(){
        while(true){
            yield return new WaitForSeconds(particleInterval);
            
            previousNode = currentNode;
            currentNode = Instantiate(curveNodePrefab, transform.position, Quaternion.identity);
            currentNode.GetComponent<CurveNodeController>().SetPreviousNode(previousNode);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        HandleInput();
	}
    
    void HandleInput(){
        bod.velocity = new Vector3(3 * Input.GetAxis("Horizontal"), 3 * Input.GetAxis("Vertical"), 0);
        
        Vector3 oppositeVelocity = new Vector3(-transform.position.x, -transform.position.y, 0);
        
        if(Mathf.Abs(transform.position.y) > 0.7){
            bod.velocity += oppositeVelocity * 0.5f;
        }
        
        if(Mathf.Abs(transform.position.x) > 1){
            bod.velocity += oppositeVelocity * 1f;
        }
        
        bod.velocity += oppositeVelocity * 0.5f;
        
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
