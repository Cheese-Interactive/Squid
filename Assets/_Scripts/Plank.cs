using System.Collections;
using UnityEngine;

public class Plank : MonoBehaviour {

    [SerializeField] private float aliveTime;


    void Start() {
        StartCoroutine(QueueForDestruction(aliveTime));
    }

    private IEnumerator QueueForDestruction(float t) {
        yield return new WaitForSeconds(t);
        Destroy(gameObject);
    }
}
