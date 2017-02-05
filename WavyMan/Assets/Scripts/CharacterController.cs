using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    private Rigidbody bod;
    public GameObject Sword;
    private GameObject currentNode = null;
    private GameObject previousNode = null;
    public GameObject curveNodePrefab;

    private FabioAnimator fabio;

    public float particleInterval = 0.1f;

    void Awake() {
        bod = GetComponent<Rigidbody>();
    }

    void Start() {
        StartCoroutine(SpawnParticle());
        fabio = FindObjectOfType<FabioAnimator>();
    }

    IEnumerator SpawnParticle() {
        while (true) {
            yield return new WaitForSeconds(particleInterval);

            previousNode = currentNode;
            currentNode = Instantiate(curveNodePrefab, transform.position, Quaternion.identity);
            currentNode.GetComponent<TrailNodeController>().SetPreviousNode(previousNode);
        }
    }

    void FixedUpdate() {
        HandleInput();
    }

    void HandleInput() {
        bod.velocity = new Vector3(3 * Input.GetAxis("Horizontal"), 3 * Input.GetAxis("Vertical"), 0);

        Vector3 oppositeVelocity = new Vector3(-transform.position.x, -transform.position.y, 0);

        if (Mathf.Abs(transform.position.y) > 0.7) {
            bod.velocity += oppositeVelocity * 0.5f;
        }

        if (Mathf.Abs(transform.position.x) > 1) {
            bod.velocity += oppositeVelocity * 1f;
        }

        bod.velocity += oppositeVelocity * 0.5f;

        float swordHorizontal = Input.GetAxis("SwordHorizontal");
        float swordVertical = Input.GetAxis("SwordVertical");

        if (Sword != null) {
            Sword.transform.localPosition = new Vector3((swordHorizontal) * 0.3f, (swordVertical) * 0.3f, 0);
            if (swordVertical < 0) {
                Sword.transform.rotation = Quaternion.Euler(0, 0, 270 + swordHorizontal * 90);
            } else {
                Sword.transform.rotation = Quaternion.Euler(0, 0, 90 + swordHorizontal * -90);
            }
            //fabio.ArmPosition(7 - (((Sword.transform.rotation.eulerAngles.z % 360) / 360) - 90) * 7);
            //print(Sword.transform.rotation.eulerAngles.z);
            float swordRot = Sword.transform.rotation.eulerAngles.z;
            if (swordRot < 247.5f && swordRot >= 202.5) {
                // left down
                fabio.ArmPosition(1);
            } else if (swordRot < 202.5 && swordRot >= 157.5) {
                // left
                fabio.ArmPosition(2);
            } else if (swordRot < 157.5f && swordRot >= 112.5) {
                // left up
                fabio.ArmPosition(3);
            } else if (swordRot < 112.5f && swordRot >= 67.5) {
                // up
                fabio.ArmPosition(4);
            } else if (swordRot < 67.5 && swordRot >= 22.5) {
                // right up
                fabio.ArmPosition(5);
            } else if (swordRot < 22.5f && swordRot >= 0 || swordRot <= 360f && swordRot >= 337.5) {
                // right
                fabio.ArmPosition(6);
            } else if (swordRot < 337.5f && swordRot >= 292.5) {
                // right down
                fabio.ArmPosition(7);
            } else if (swordRot < 292.5f && swordRot >= 247.5) {
                // down
                fabio.ArmPosition(8);
            } else {
                print("this shouldnt happen, something went wrong with calculating the arm positions");
                print(Sword.transform.rotation.eulerAngles.z);
            }
        }
    }
}