using System;
using UnityEngine;

public class TrackTriggerEvent : MonoBehaviour {

    public ScoreCounter score;

    private void OnTriggerEnter2D(Collider2D other) {
        score.scoreMultiplier = 1;
    }

    private void OnTriggerExit2D(Collider2D other) {
        score.scoreMultiplier = 0;
    }

    private void OnTriggerStay2D(Collider2D other) {
        score.scoreMultiplier = 1;
    }
}