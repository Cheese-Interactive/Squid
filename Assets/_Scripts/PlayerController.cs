using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private int score;
    [Header("Movement")]
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    [Header("Fortnite ahh stuff")]
    [SerializeField] private int mats;
    [SerializeField] private GameObject placer;
    private SpriteRenderer placerSprite;
    [SerializeField] private Plank plankPrefab;
    [SerializeField] private float buildDelay;
    [SerializeField] private Plank currentPlank;
    private bool canBuild;
    [Header("UI")]
    [SerializeField] private GameObject matsTextShower;
    private TextMeshProUGUI matsText;
    [SerializeField] private GameObject scoreTextShower;
    private TextMeshProUGUI scoreText;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        canBuild = true;
        matsText = matsTextShower.GetComponent<TextMeshProUGUI>();
        scoreText = scoreTextShower.GetComponent<TextMeshProUGUI>();
        placerSprite = placer.GetComponent<SpriteRenderer>();
    }

    void Update() {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed; //lame
        drowningCheck();
        updateUiText();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        placer.transform.position = new Vector3(mousePos.x, mousePos.y, 1);
        if (Input.GetMouseButtonDown(0) && canBuild) {
            if (mats != 0)
                StartCoroutine(BuildCooldown(buildDelay));
            Instantiate(plankPrefab, placer.transform.position, placer.transform.rotation);
            mats--;
        }
        if (Input.GetMouseButtonDown(1)) {
            Quaternion rot = placer.transform.rotation;
            placer.transform.rotation = Quaternion.Euler(rot.eulerAngles.x, rot.eulerAngles.y, rot.eulerAngles.z + 90);
            print(rot.eulerAngles);
        }
        if (mats == 0)
            canBuild = false;
        if (!canBuild)
            placerSprite.enabled = false;
        if (canBuild)
            placerSprite.enabled = true;



    }
    private void OnTriggerEnter2D(Collider2D c) {
        GameObject colObj = c.gameObject;
        if (colObj.GetComponent<Pickup>() != null)
            colObj.GetComponent<Pickup>().interact();
    }


    private void drowningCheck() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, transform.localScale.x / 2, Vector3.zero, 0);
        foreach (RaycastHit2D hit in hits) {
            if (hit.rigidbody.gameObject.CompareTag("Plank")) {
                //if touching plank, you're good 
                currentPlank = hit.rigidbody.gameObject.GetComponent<Plank>();
                return;
            }
        }
        Destroy(gameObject);//need death animation

    }

    private IEnumerator BuildCooldown(float t) {
        canBuild = false;
        yield return new WaitForSeconds(t);
        canBuild = true;
    }

    private void updateUiText() {

        matsText.text = "" + mats;
        scoreText.text = "" + score;
    }

    public void giveMats(int m) {
        mats += m;
    }
}

