using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    public int score;
    public int scoreMultiplier;

    public Transform car;
    private Rigidbody2D _rb;

    public Text scoreText;
    public Text triggerText;

    void Start() {
        score = 0;
        
        scoreText = GetComponent<Text>();
        scoreText.text = "0";

        _rb = car.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate() {
        var carAngle = Mathf.Acos(Vector2.Dot(_rb.velocity.normalized, car.up.normalized)) * Mathf.Rad2Deg;
        if (carAngle > 15) {
            score += (int) (carAngle / 100 * _rb.velocity.magnitude) * scoreMultiplier;
            
            triggerText.gameObject.SetActive(true);
        } else {
            triggerText.gameObject.SetActive(false);
        }
        

        scoreText.text = score.ToString();
    }
}