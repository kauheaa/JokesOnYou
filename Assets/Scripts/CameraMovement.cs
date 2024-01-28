using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float cameraOffset = 2.0f;
    public float smoothSpeed = 5.0f;

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Calculate target position for the camera
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, playerTransform.position.z - cameraOffset);

            // Smoothly move the camera towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
