using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {

	public float burstSpeed;
    public GameObject swordTrailNode;
    private GameObject currentNode = null;
    private GameObject previousNode = null;
    public ParticleSystem particles;

	private List<GameObject> nodeList = new List<GameObject>();
    
	void Start () {
		particles.Stop();
	}

	void FixedUpdate () {
        if(Input.GetButton("Swing")) {
            if(!particles.isEmitting) {
				Fabric.EventManager.Instance.PostEvent("Sword", Fabric.EventAction.PlaySound);
				BurstOff ();
                particles.Play();
            }
            previousNode = currentNode;
            currentNode = Instantiate(swordTrailNode, transform.position, Quaternion.identity);
            currentNode.GetComponent<TrailNodeController>().SetPreviousNode(previousNode);
			currentNode.GetComponent<TrailNodeController> ().SetMaster (gameObject);
			nodeList.Add (currentNode);

        } else if(particles.isEmitting){
			Fabric.EventManager.Instance.PostEvent("Sword", Fabric.EventAction.StopSound);
			particles.Stop();
			BurstOn ();
        }
	}

	public void ChildDying(GameObject obj) {
		nodeList.Remove (obj);
	}

	void BurstOn() {
		if (burstSpeed != 1.0f) {
			var main = particles.main;
			main.simulationSpeed = burstSpeed;
			setSpeedMultipliers (burstSpeed);
		}
	}

	void BurstOff() {
		if (burstSpeed != 1.0f) {
			var main = particles.main;
			main.simulationSpeed = 1.0f;
			setSpeedMultipliers (1.0f);
		}
	}

	void setSpeedMultipliers(float multiplier) {
		foreach (GameObject obj in nodeList) {
			obj.SendMessage ("SetSpeedMultiplier", multiplier);
		}
	}
}
