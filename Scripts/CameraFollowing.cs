using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Camera must only move, when the player is going upwards.
public class CameraFollowing : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;

    // Use LateUpdate, so the player's position will be transformed by that time.
    void LateUpdate()
    {
        // If the target is above the camera, move camera to target's position.
        if (targetToFollow.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, targetToFollow.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
