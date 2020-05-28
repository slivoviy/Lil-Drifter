using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClippingPointTriggerEvent : MonoBehaviour {
    public ScoreCounter score;

    public Text triggerText;

    private bool _wasThere;

    private void OnTriggerEnter2D(Collider2D other) {
        if (_wasThere) return;
        score.score += 250;
            
        _wasThere = true;
            
        StartCoroutine(Texter());
    }

    private IEnumerator Texter() {
        triggerText.text = "+250";
        
        yield return new WaitForSeconds(2);

        triggerText.text = "";
        triggerText.gameObject.SetActive(false);
    }
}
