using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveNodeController : MonoBehaviour
{

    public Vector3 translation;
    public float timeToLive = 10;
    public float strength;

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

    public void SetStrength(float strength)
    {
        this.strength = strength;
        //transform.GetChild(1).localScale = Vector3.one * strength;
    }

    private IEnumerator DisableAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
