using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Animator animator;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        // Set the "isRunning" trigger in the Animator
        if (animator != null)
        {
            if (movementDirection.magnitude > 0f)
            {
                animator.SetTrigger("isRunning");
            }
            else
            {
                animator.ResetTrigger("isRunning");
            }
        }

        if (movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
        }
    }
}
