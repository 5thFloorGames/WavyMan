using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailNodeController : MonoBehaviour
{
    public Vector3 translation;
    public float timeToLive = 10;
    public float strength;
	public GameObject master;

	private float speedMultiplier;

    void OnEnable()
    {
		speedMultiplier = 1.0f;
        StartCoroutine(DisableAfterDelay(timeToLive));
    }

    void Update()
    {
		transform.position += (translation * Time.deltaTime * speedMultiplier);
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

	public void SetMaster(GameObject obj) {
		master = obj;
	}

	public void SetSpeedMultiplier(float multiplier) {
		speedMultiplier = multiplier;
	}

    private IEnumerator DisableAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
		if (gameObject.tag == "Wave") {
			master.GetComponent<SwordController> ().ChildDying(gameObject);
		}
        gameObject.SetActive(false);
    }
}
