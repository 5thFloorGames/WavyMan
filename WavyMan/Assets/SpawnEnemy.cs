using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    private GameObject EnemyNode;


    void Awake(){
        EnemyNode = Resources.Load<GameObject>("Enemy Node");
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
            yield return new WaitForSeconds(0.5f);
            Instantiate(EnemyNode, transform.position + (new Vector3(Random.Range(-1f,1f), Random.Range(-0.7f, 0.7f), 0)), Quaternion.identity);
        }
    }
}
