using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextJuiciness : MonoBehaviour {

    public AnimationCurve textDisplayCurve;
    public float lifeTime;
    private float time;


    void Start() {
        StartCoroutine(JuicyEffect());

    }


    void Update() {

    }

    IEnumerator JuicyEffect() {
        while (time < lifeTime) {
            time += Time.deltaTime;
            transform.localScale = new Vector3(textDisplayCurve.Evaluate(time), textDisplayCurve.Evaluate(time), textDisplayCurve.Evaluate(time));
            yield return null;
        }
    }
}