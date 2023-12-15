using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    private float moveSpeed = 40.0f; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Set the Rigidbody to not rotate due to physics interactions
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (GameLogic.gameContinue)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);

            rb.velocity = moveDirection * moveSpeed;
        }

    }
}
