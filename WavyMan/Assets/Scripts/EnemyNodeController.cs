using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNodeController : MonoBehaviour
{

    private GameController gameController;

    void Awake()
    {
        gameController = Component.FindObjectOfType<GameController>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<CurveNodeController>())
        {
			
        }
    }
}
