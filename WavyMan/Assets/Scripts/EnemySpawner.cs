using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    private GameObject EnemyNode;
    private GameController controller;
    
    private float[] spawnrates = {0.5f, 0.4f, 0.3f, 0.2f, 0.1f}; 

    void Awake(){
        EnemyNode = Resources.Load<GameObject>("Enemy");
        controller = FindObjectOfType<GameController>();
    }
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemies());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    IEnumerator SpawnEnemies(){
        while(true){
            yield return new WaitForSeconds(spawnrates[controller.getLevel()]);
            Instantiate(EnemyNode, transform.position + (new Vector3(Random.Range(-1f,1f), Random.Range(-0.7f, 0.7f), 0)), Quaternion.identity);
        }
    }
}
