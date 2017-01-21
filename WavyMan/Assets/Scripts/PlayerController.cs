using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody bod;
    public Vector3 jumpForce;
    private bool grounded = true;
    public float horizontalMaxDistanceFromCenter = 1f;
    public float verticalMaxDistanceFromCenter = 1f;
    public GameObject curveNodePrefab;
    public GameObject damageNodePrefab;
    public float horizontalSmoothness = 0.25f;
    private GameObject currentNode = null;
    private GameObject previousNode = null;
    private float horizontalDelta;

    void Awake()
    {
        bod = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleInput();
        if (horizontalDelta > 1)
        {
            //Instantiate(damageNodePrefab, previousNode.transform.position, Quaternion.identity);
        }
        previousNode = currentNode;
        currentNode = Instantiate(curveNodePrefab, transform.position, Quaternion.identity);
        currentNode.GetComponent<CurveNodeController>().SetPreviousNode(previousNode);
        currentNode.GetComponent<CurveNodeController>().SetStrength(horizontalDelta);
    }

    void OnCollisionEnter(Collision col)
    {
        grounded = true;
    }

    private void HandleInput()
    {    
        float horizontalAxisScaled = Input.GetAxis("Horizontal") * horizontalMaxDistanceFromCenter;
        float verticalAxisScaled = Input.GetAxis("Vertical") * verticalMaxDistanceFromCenter;
        
        Vector3 targetPosition = new Vector3(horizontalAxisScaled, verticalAxisScaled, transform.position.z);
        horizontalDelta = Mathf.Abs(horizontalAxisScaled - transform.position.x);
        transform.position = Vector3.Lerp(transform.position, targetPosition, horizontalSmoothness);
        
        if (Input.GetButtonDown("Jump") && grounded)
        {
            grounded = false;
            bod.velocity = jumpForce;
        }
    }
}