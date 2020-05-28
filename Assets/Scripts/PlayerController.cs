using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float torque = 200f;
    public float speed = 2f;

    float driftFactorSticky = 0.8f;
    float driftFactorSlippy = 1;
    float maxStickyVelocity = 0.5f;

    private float _negAngle;
    private float _angle;

    private Rigidbody2D _rb;

    public ParticleSystem smoke;
    public ParticleSystem smoke1;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate() {
        if (Input.touchCount > 0) {
            var pausePosition = new Rect(0, Screen.height - 300, 275, 300);
            if (!pausePosition.Contains(Input.GetTouch(0).position)) {
                var t = transform;
                _rb.AddForce(t.up * speed);

                var touchPos = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
                var torqueForce = touchPos.x * 2 - 1;
                var tf = Mathf.Lerp(0, torque, _rb.velocity.magnitude / 2);
                _rb.angularVelocity = torqueForce * tf;
                var carAngle = Mathf.Acos(Vector2.Dot(_rb.velocity.normalized, t.up.normalized)) * Mathf.Rad2Deg;
                Debug.Log(carAngle);
                if (carAngle > 15 && carAngle < 90) {
                    smoke.Emit((int) (carAngle / 10) * 2);
                   smoke1.Emit((int) (carAngle / 10) * 2);
                }
            }
        }

        var driftFactor = driftFactorSticky;
        if (RightVelocity().magnitude > maxStickyVelocity) {
            driftFactor = driftFactorSlippy;
        }

        _rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;
    }

    Vector2 ForwardVelocity() {
        return transform.up * Vector2.Dot(_rb.velocity, transform.up);
    }

    Vector2 RightVelocity() {
        return transform.right * Vector2.Dot(_rb.velocity, transform.right);
    }
}