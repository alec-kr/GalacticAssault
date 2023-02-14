using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    private bool isVisible = true;
    private bool isWrappingX = true;
    private bool isWrappingY = true;
    Vector3 currPosition;
    Vector3 newPosition;

    private void FixedUpdate() {
        ScreenWrap();
    }

    public void ScreenWrap() {
        if(isVisible) {
            isWrappingX = false;
            isWrappingY = false;
            return;
        }

        // If wrapping on both axes, return
        if (isWrappingX && isWrappingY) {
            return;
        }

        // If not wrapping X, but X position is out of bounds
        if(!isWrappingX && (currPosition.x > 0.9f || currPosition.x < 0.1f)) {
            // Update X position
            newPosition.x = -currPosition.x;
            // Set isWrappingX to true
            isWrappingX = true;
        }

        // If not wrapping Y, but Y position is out of bounds
        if(!isWrappingY && (currPosition.y > 0.9f || currPosition.y < 0.1f)) {
            // Update Y position
            newPosition.y = -currPosition.y;
            // Set isWrappingY to true
            isWrappingY = true;
        }

        // Update the object's position with the new coordinates
        transform.position = newPosition;
    }

    // Called when object is no longer visible by camera
    public void OnBecameInvisible() {
        isVisible = false;
        currPosition = transform.position;
    }

    // Called when object becomes visible to the camera
    public void OnBecameVisible() {
        isVisible = true;
    }
}
