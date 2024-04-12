using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [Header("Prefabs/References")]
    [SerializeField] private Coin pointsPrefab;
    [SerializeField] private Materials matsPrefab;
    [SerializeField] private GameObject timeTextObject;
    private TextMeshProUGUI timeText;
    [Header("Spawning")]
    [SerializeField] private int pointsToSpawn;
    [SerializeField] private int matsToSpawn;
    [SerializeField] private Vector2 upLeftBound;
    [SerializeField] private Vector2 downRightBound;
    [Header("Squid")]
    [SerializeField] private GameObject[] tentaclePrefabs;
    [SerializeField] private float tentacleRotMod;
    [SerializeField] private int maxTentacles;
    [SerializeField] private float tentaclesDelay;
    // Start is called before the first frame update
    void Start() {
        timeText = timeTextObject.GetComponent<TextMeshProUGUI>();
        spawnPts(2);
        spawnMats(2);
        StartCoroutine(spawnTentacles());
    }

    // Update is called once per frame
    void Update() {
        timeText.text = "" + (int)Time.time;
    }

    public void spawnPts(int p) {
        for (int i = 0; i < p; i++)
            Instantiate(pointsPrefab, genRandCoord(), Quaternion.identity);
    }

    public void spawnMats(int m) {
        for (int i = 0; i < m; i++)
            Instantiate(matsPrefab, genRandCoord(), Quaternion.identity);
    }
    public void spawnMats() {
        for (int i = 0; i < matsToSpawn; i++)
            Instantiate(matsPrefab, genRandCoord(), Quaternion.identity);
    }

    private IEnumerator spawnTentacles() {
        yield return new WaitForSeconds(tentaclesDelay);
        for (int i = 0; i < Random.Range(1, maxTentacles); i++) {
            // 50/50 for the tentacle spawned to be vertical or horizontal
            GameObject selected = tentaclePrefabs[Random.Range(0, tentaclePrefabs.Length - 1)];
            if (Random.Range(0, 100) < 50)
                Instantiate(selected, genRandCoord(), Quaternion.Euler(0, 0, 0 + Random.Range(-tentacleRotMod, tentacleRotMod)));
            else
                Instantiate(selected, genRandCoord(), Quaternion.Euler(0, 0, 90 + Random.Range(-tentacleRotMod, tentacleRotMod)));
            yield return new WaitForSeconds(0.8f);
        }
        yield return new WaitForSeconds(tentaclePrefabs[0].GetComponent<Spawnable>().getAliveTime());
        StartCoroutine(spawnTentacles());
    }

    private Vector2 genRandCoord() {
        //Random Vector2 within bounds
        return new Vector2(Random.Range(upLeftBound.x, downRightBound.x),
                            Random.Range(downRightBound.y, upLeftBound.y));
    }

}
