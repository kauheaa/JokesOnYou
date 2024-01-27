using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    public Camera plazaCamera;
    public Camera storeCamera;
    public Camera devCamera;
    public Camera kitchenCamera;

    private GameObject player; // Reference to the player GameObject

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Debug.Log(player.transform.position + "");
        if (player != null)
        {
            SwitchCameraBasedOnRoom(player.transform.position);
        }
    }
    void SwitchCameraBasedOnRoom(Vector3 playerPosition)
    {

        if (IsPlayerInKitchen(playerPosition))
        {
            ActivateCamera(kitchenCamera);
            Debug.Log("Switching to Kitchen Camera");
        }
        else if (IsPlayerInPlaza(playerPosition))
        {
            ActivateCamera(plazaCamera);
            Debug.Log("Switching to Plaza Camera");
        }
        else if (IsPlayerInDevRoom(playerPosition))
        {
            ActivateCamera(devCamera);
            Debug.Log("Switching to Dev Camera");
        }
        else if (IsPlayerInStore(playerPosition))
        {
            ActivateCamera(storeCamera);
            Debug.Log("Switching to Store Camera");
        }
    }

    void ActivateCamera(Camera targetCamera)
    {
        DisableAllCameras();

        Debug.Log($"Enabling {targetCamera.name}");
        // Activate the target camera
        targetCamera.enabled = true;
    }

    void DisableAllCameras()
    {
        // Disable all cameras in the scene
        Camera[] allCameras = Camera.allCameras;
        foreach (Camera camera in allCameras)
        {
            camera.enabled = false;
        }
    }

    bool IsPlayerInKitchen(Vector3 playerPosition)
    {
        return playerPosition.z < -7 && playerPosition.x < -15;
    }

    bool IsPlayerInPlaza(Vector3 playerPosition)
    {
        return playerPosition.z >= -7f && playerPosition.x < 15f;
    }

    bool IsPlayerInDevRoom(Vector3 playerPosition)
    {
        return playerPosition.x >= 2.6f && playerPosition.x < 3.6f;
    }

    bool IsPlayerInStore(Vector3 playerPosition)
    {
        return playerPosition.x >= -50f && playerPosition.x < -35f && playerPosition.z >= 0f && playerPosition.z < -15f;
    }
}