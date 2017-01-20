using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody bod;
    public Vector3 jumpForce;
    private bool grounded = true;

    void Awake()
    {
        bod = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleInput();
    }

    void OnCollisionEnter(Collision col)
    {
        grounded = true;
    }

    private void HandleInput()
    {
        transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0));
        if (Input.GetButtonDown("Jump") && grounded)
        {
            grounded = false;
            bod.velocity = jumpForce;
        }
    }
}
