using UnityEngine;

public class GameManager : MonoBehaviour {
    [Header("Prefabs")]
    [SerializeField] private Coin pointsPrefab;
    [SerializeField] private Materials matsPrefab;
    [Header("Spawning")]
    [SerializeField] private int pointsToSpawn;
    [SerializeField] private int matsToSpawn;
    [SerializeField] private Vector2 upLeftBound;
    [SerializeField] private Vector2 downRightBound;
    // Start is called before the first frame update
    void Start() {
        spawnPts(2);
        spawnMats(3);
    }

    // Update is called once per frame
    void Update() {

    }

    public void spawnPts(int p) {
        for (int i = 0; i < p; i++) {
            Instantiate(pointsPrefab,
                new Vector2(Random.Range(upLeftBound.x, downRightBound.x),
                            Random.Range(downRightBound.y, upLeftBound.y)),
                Quaternion.identity);
        }

    }

    public void spawnMats(int m) {
        for (int i = 0; i < m; i++) {
            Instantiate(matsPrefab,
                new Vector2(Random.Range(upLeftBound.x, downRightBound.x),
                            Random.Range(downRightBound.y, upLeftBound.y)),
                Quaternion.identity);
        }
    }
    public void spawnMats() {
        for (int i = 0; i < matsToSpawn; i++) {
            Instantiate(matsPrefab,
                new Vector2(Random.Range(upLeftBound.x, downRightBound.x),
                            Random.Range(downRightBound.y, upLeftBound.y)),
                Quaternion.identity);
        }
    }

}
