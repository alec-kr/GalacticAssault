using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    private bool isVisible = true;
    private bool isWrappingX = true;
    private bool isWrappingY = true;
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

        if (isWrappingX && isWrappingY) {
            return;
        }

        if(!isWrappingX && (newPosition.x > 1 || newPosition.x < 0)) {
            newPosition.x = -newPosition.x;
            isWrappingX = true;
        }

        if(!isWrappingY && (newPosition.y > 1 || newPosition.y < 0)) {
            newPosition.y = -newPosition.y;
            isWrappingY = true;
        }

        transform.position = newPosition;
    }

    public void OnBecameInvisible() {
        isVisible = false;
        newPosition = transform.position;
    }

    public void OnBecameVisible() {
        isVisible = true;
    }
}
