using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody bod;
    public Vector3 jumpForce;
    private bool grounded = true;
    public float horizontalVelocity = 2;
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
        transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * horizontalVelocity * Time.deltaTime, 0));
        if (Input.GetButtonDown("Jump") && grounded)
        {
            grounded = false;
            bod.velocity = jumpForce;
        }
    }
}
