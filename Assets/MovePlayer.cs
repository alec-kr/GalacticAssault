using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public ParticleSystem rocketThruster;
    private float thrustSpeed = 6.0f;
    private float turnSpeed = 1.5f;
    private Rigidbody2D _rigidbody;
    private bool _thrusting;
    private float _turnDirection;
    Vector3 currentPos;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _thrusting = Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.LeftArrow))
            _turnDirection = 1.0f;

        else if (Input.GetKey(KeyCode.RightArrow))
            _turnDirection = -1.0f;
        else
            _turnDirection = 0.0f;
    }

    private void FixedUpdate() {
        if(_thrusting) {
            _rigidbody.AddForce(this.transform.up * this.thrustSpeed);
            rocketThruster.Play();
        }
        else
            rocketThruster.Stop();

        if(_turnDirection != 0.0f)
            _rigidbody.AddTorque(_turnDirection * this.turnSpeed);
    }
}