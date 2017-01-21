using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNodeController : MonoBehaviour
{

    private GameController gameController;
    private Rigidbody rigidBody;
	private GameObject splashEffect;

    void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(0,0,-1 * Random.Range(0.1f, 1.5f));
		splashEffect = Resources.Load <GameObject>("Splash Effect");
    }
    
    void Update(){

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Wave"){
			gameController.AddPoints();
            Destroy(gameObject);
        }
    }

	void SpawnSplash() {
		Instantiate(splashEffect, transform.position, Quaternion.identity);
	}
}
