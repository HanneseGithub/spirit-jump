using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapping : MonoBehaviour
{
    // Method fires whenever object's renderer is no longer visible by any camera (not active).
    private void OnBecameInvisible()
    {
        // If i were to destroy this object, it will set it to be not active.
        // It will also disable the renderer, so it would trigger OnBecameInvisible.
        // We need to make sure that OnBecameInvisible is triggered only when we go off the screen, not when we die and stuff.
        // This makes sure that the screen wrapping object is still active and still "alive", but just invisible.
        if (this.gameObject.activeSelf)
        {
            Vector2 thisPosition = transform.position;

            // Camera.main - any camera with the main tag on it.
            // WorldToViewportPoint will take the world object (all of our objects, spirtes etc what are in the world) their x/y value.
            // And it will convert it to viewport points, which are gonna be from 0 to 1 depending on where at it is from 0 - 1. Left or right, bottom to top.

            // If the x position is over 1, it means we are off the screen to the right. If it's under 0, it means we are off the screen to the left.
            if (Camera.main.WorldToViewportPoint(transform.position).x > 1 || Camera.main.WorldToViewportPoint(transform.position).x < 0)
            {
                thisPosition.x = -thisPosition.x;
            }

            transform.position = thisPosition;
        }
    }
}
