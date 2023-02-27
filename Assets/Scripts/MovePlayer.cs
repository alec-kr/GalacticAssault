using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to move the player's ship
public class MovePlayer : MonoBehaviour
{
    // The ship's acceleration speed
    private float thrustSpeed = 6.0f;
    // The ship's turning speed
    private float turnSpeed = 15.0f;
    private Rigidbody2D _rigidbody;
    private bool _thrusting;
    private float _turnDirection;
    private GameObject thruster;
    Vector3 currentPos;

    private void Awake() {
        // Get the thruster attached to the ship RigidBody
        _rigidbody = GetComponent<Rigidbody2D>();
        thruster = gameObject.transform.Find("Thruster").gameObject;
    }

    private void Update() {
        // Check if the up arrow is being pressed
        _thrusting = Input.GetKey(KeyCode.UpArrow);

        // If the left arrow is pressed, turn left
        if (Input.GetKey(KeyCode.LeftArrow))
            _turnDirection = 1.0f;

        // If the right arrow is pressed, turn right
        else if (Input.GetKey(KeyCode.RightArrow))
            _turnDirection = -1.0f;
        
        // Else, stop turning
        else
            _turnDirection = 0.0f;
    }

    private void FixedUpdate() {
        // If the up arrow is being pressed
        if(_thrusting) {
            // Add a positive force to the ship
            _rigidbody.AddForce(this.transform.up * this.thrustSpeed);
            // Activate the ship's thruster
            thruster.SetActive(true);
        }

        // Else, deactivate the thruster
        else {
            thruster.SetActive(false);
        }

        // If left/right key is pressed, turn in that particular direction
        if(_turnDirection != 0.0f)
            _rigidbody.AddTorque(_turnDirection * this.turnSpeed);
    }
}