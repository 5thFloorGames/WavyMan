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
    public float horizontalSmoothness = 0.25f;

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
        Vector3 targetPosition = new Vector3(Input.GetAxis("Horizontal") * horizontalMaxDistanceFromCenter, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, horizontalSmoothness);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            grounded = false;
            bod.velocity = jumpForce;
        }
    }
}
