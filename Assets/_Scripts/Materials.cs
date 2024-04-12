using UnityEngine;
public class Materials : Pickup {
    [SerializeField] private int matsToGive;
    public override void interact() {
        player.giveMats(4);
        GameObject.Destroy(gameObject);
    }
}
