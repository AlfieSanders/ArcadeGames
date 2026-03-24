using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    // Creates variables to be used ini this script.

    private Rigidbody2D rb;
    [SerializeField] private float speed = 20f;
    private Vector2 inputVector;


    // Awake is called before the first frame update
    void Awake()
    {
        // Gets the RidgidBody and sets as variable (created above).
        rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        // Runs the function that moves the character.
        UpdateCharacterMovement();
    }

    private void UpdateCharacterMovement()
    {
        // If inputVecotr is greater than 0, add a force to our player.
        if (inputVector != Vector2.zero)
        {
            rb.AddForce(inputVector * speed * Time.fixedDeltaTime);
        }

        // If input vector is greater than 0, interpolate Player rotation to the forward vector of the RidgidBody.
        if (rb.linearVelocity != Vector2.zero) 
        {
            rb.MoveRotation(Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg);
        }
    }

    // Sets our input vector based on the Input Value of the Joystick Input Action (Vector2).
    public void OnJoystick(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

}
