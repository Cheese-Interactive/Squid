using UnityEngine;
public class Coin : Pickup {
    [SerializeField] private int pointsToGive;
    public override void interact() {
        player.givePoints(pointsToGive);
        FindObjectOfType<GameManager>().spawnMats();
        FindObjectOfType<GameManager>().spawnPts(2);
        Destroy(gameObject);
    }
}
