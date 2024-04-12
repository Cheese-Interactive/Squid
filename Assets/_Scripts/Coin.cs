using UnityEngine;
public class Coin : Pickup {
    [SerializeField] private int pointsToGive;
    public override void interact() {
        player.givePoints(pointsToGive);
        Destroy(gameObject);
    }
}
