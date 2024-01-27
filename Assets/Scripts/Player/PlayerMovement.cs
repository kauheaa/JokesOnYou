using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the same GameObject
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

        // Update animator parameters based on movement
        UpdateAnimatorParameters(horizontal, vertical);
    }
    void UpdateAnimatorParameters(float horizontal, float vertical)
    {
        // Check if there is any movement
        bool isMoving = (horizontal != 0f || vertical != 0f);

        // Update the "isMoving" parameter in the Animator
        animator.SetBool("isMoving", isMoving);

        // If moving, set the direction for the blend tree
        if (isMoving)
        {
            float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            float blendValue = Mathf.InverseLerp(-180f, 180f, angle);
            animator.SetFloat("moveDirection", blendValue);
        }
    }
}
