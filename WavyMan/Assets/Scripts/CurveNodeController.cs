using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveNodeController : MonoBehaviour
{

    public Vector3 translation;
    public float timeToLive = 10;

    void OnEnable()
    {
        StartCoroutine(DisableAfterDelay(timeToLive));
    }

    void Update()
    {
        transform.position += (translation * Time.deltaTime);
    }

    public void SetPreviousNode(GameObject node)
    {
        if (node != null)
        {
            transform.LookAt(node.transform);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Vector3.Distance(transform.position, node.transform.position) * 1.1f);
        }
    }

    private IEnumerator DisableAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
