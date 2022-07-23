using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float Jumpforce = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Poruszanie siê gracza w osiach X/Y
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3 (horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        
        if (Input.GetButton("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, Jumpforce, rb.velocity.z);
        }
    }

}
