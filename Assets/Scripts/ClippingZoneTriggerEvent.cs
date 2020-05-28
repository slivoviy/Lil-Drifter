using System;
using UnityEngine;
using UnityEngine.UI;

public class ClippingZoneTriggerEvent : MonoBehaviour {
    public ScoreCounter score;
    
    public Text textEvent;

    private void OnTriggerEnter2D(Collider2D other) {
        score.scoreMultiplier = 5;

        textEvent.text = "x5";
        textEvent.gameObject.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other) {
        score.scoreMultiplier = 5;
    }

    private void OnTriggerExit2D(Collider2D other) {
        score.scoreMultiplier = 0;

        textEvent.text = "";
    }
}