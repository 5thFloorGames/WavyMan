using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNodeController : MonoBehaviour
{

    private GameController gameController;
    private Rigidbody rigidBody;

    void Awake()
    {
        gameController = Component.FindObjectOfType<GameController>();
        rigidBody = GetComponent<Rigidbody>();
    }
    
    void Update(){
        rigidBody.AddForce(new Vector3(0f,0f,-0.1f));
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player"){
            print("Hit a thing!");
            Destroy(gameObject);
        }
    }
}
