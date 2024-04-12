using System.Collections;
using UnityEngine;

public class Spawnable : MonoBehaviour {
    [SerializeField] protected int aliveTime;
    void Start() {
        StartCoroutine(QueueForDeletion());
    }
    private IEnumerator QueueForDeletion() {
        for (int i = aliveTime; i >= 0; i--) {
            yield return new WaitForSeconds(1);
        }
        Destroy(gameObject);
    }

    public int getAliveTime() {
        return aliveTime;
    }
}
