using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    public float turnSpeed = 1;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input from the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        // Move the player
        transform.Translate(movement * speed * Time.deltaTime);

        // Check if either horizontal or vertical movement is greater than 0
        bool isRunning = horizontal > 0f || vertical > 0f;

        // Set the "isRunning" parameter in the Animator
        if (animator != null)
        {
            animator.SetBool("isRunning", isRunning);
        }
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }

    }
}
