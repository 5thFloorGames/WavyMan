using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody bod;
    public Vector3 jumpForce;
    private bool grounded = true;
    public float horizontalMaxDistanceFromCenter = 2;
    public GameObject curveNodePrefab;

    void Awake()
    {
        bod = GetComponent<Rigidbody>();
        StartCoroutine(SpawnCurveNodes());
    }

    void Update()
    {
        HandleInput();
    }

    void OnCollisionEnter(Collision col)
    {
        grounded = true;
    }

    private IEnumerator SpawnCurveNodes()
    {
        while (true)
        {
            Instantiate(curveNodePrefab, transform.position, Quaternion.identity);
            yield return null;
        }
    }

    private void HandleInput()
    {
        transform.position = new Vector3(Input.GetAxis("Horizontal") * horizontalMaxDistanceFromCenter, transform.position.y, transform.position.z);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            grounded = false;
            bod.velocity = jumpForce;
        }
    }
}
