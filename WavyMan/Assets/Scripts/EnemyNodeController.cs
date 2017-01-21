using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNodeController : MonoBehaviour
{

    private GameController gameController;
    private Rigidbody rigidBody;

    void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(0,0,-1 * Random.Range(0.1f, 1.5f));
    }
    
    void Update(){

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Wave"){
            Destroy(gameObject);
            gameController.AddPoints();
        }
    }
}
