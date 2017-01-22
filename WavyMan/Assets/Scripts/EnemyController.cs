using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private GameController gameController;
    private Rigidbody rigidBody;
	private GameObject splashEffect;
	private Animator animator;

    void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(0,0,-1 * Random.Range(0.1f, 1.5f) - 0.2f * gameController.getLevel());
		splashEffect = Resources.Load <GameObject>("Splash Effect");
		animator = gameObject.GetComponentInChildren<Animator> ();
		RandomAnimation ();
    }
    
    void Update(){

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Wave"){
			gameController.AddPoints();
			SpawnSplash ();
            Destroy(gameObject);
        }
    }

	void SpawnSplash() {
		Instantiate(splashEffect, transform.position, Quaternion.identity);
	}

	void RandomAnimation() {
		int animnumber = Random.Range (0,3);
		if (animnumber == 0) {
			animator.SetTrigger ("O");
		} else if (animnumber == 1) {
			animator.SetTrigger ("Gasm");
		} else {
			animator.SetTrigger ("Bite");
		}

	}
}
