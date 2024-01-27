using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera targetCamera;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate the target camera
            targetCamera.enabled = true;

            // Disable all other cameras
            Camera[] allCameras = Camera.allCameras;
            foreach (Camera camera in allCameras)
            {
                if (camera != targetCamera)
                {
                    camera.enabled = false;
                }
            }
        }
    }
}