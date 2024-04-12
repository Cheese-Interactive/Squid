using System.Collections;
using TMPro;
using UnityEngine;

public abstract class Pickup : MonoBehaviour {
    [SerializeField] private int aliveTime;
    [SerializeField] private GameObject textObject;
    private TextMeshPro cdText;
    protected PlayerController player;
    public abstract void interact();

    void Start() {
        player = GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        cdText = textObject.GetComponent<TextMeshPro>();
        StartCoroutine(QueueForDeletion());
    }

    private IEnumerator QueueForDeletion() {
        for (int i = aliveTime; i >= 0; i--) {
            cdText.text = "" + i;
            yield return new WaitForSeconds(1);
        }
        Destroy(gameObject);
    }

}
