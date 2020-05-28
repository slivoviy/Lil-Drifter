using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler {
    private Vector3 _panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public int totalPages = 3;
    private int _currentPage;

    void Start() {
        _currentPage = PlayerPrefs.GetInt("current_car", 0) + 1;
        switch (_currentPage) {
            case 1:
                transform.position += new Vector3(0, 0, 0);
                break;
            case 2:
                transform.position += new Vector3(-Screen.width, 0, 0);
                break;
            case 3:
                transform.position += new Vector3(-Screen.width*2, 0, 0);
                break;
        }
        _panelLocation = transform.position;
    }

    public void OnDrag(PointerEventData data) {
        float difference = data.pressPosition.x - data.position.x;
        transform.position = _panelLocation - new Vector3(difference, 0, 0);
    }

    public void OnEndDrag(PointerEventData data) {
        Debug.Log(Screen.width);
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= percentThreshold) {
            Vector3 newLocation = _panelLocation;
            Debug.Log("hi");
            if (percentage > 0 && _currentPage < totalPages) {
                _currentPage++;
                CarChoiceScript.CurrentCarPanel++;
                newLocation += new Vector3(-Screen.width, 0, 0);
                Debug.Log(newLocation);
            }
            else if (percentage < 0 && _currentPage > 1) {
                _currentPage--;
                CarChoiceScript.CurrentCarPanel--;
                newLocation += new Vector3(Screen.width, 0, 0);
                Debug.Log(newLocation);
            }

            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            _panelLocation = newLocation;
        }
        else {
            StartCoroutine(SmoothMove(transform.position, _panelLocation, easing));
        }
    }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds) {
        float t = 0f;
        while (t <= 1.0) {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}