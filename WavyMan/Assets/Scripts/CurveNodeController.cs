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
        transform.Translate(translation * Time.deltaTime);
    }

    private IEnumerator DisableAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
