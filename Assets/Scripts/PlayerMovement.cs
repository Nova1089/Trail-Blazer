using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] float gravity = -30f;
    [SerializeField] float baseSpeed = 1f;
    [SerializeField] float jumpHeight = 1f;
    [SerializeField] float boostModifier = 1f;
    [SerializeField] int numberOfJumps = 2;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float capsuleRadius;

    CharacterController characterController;
    Vector3 velocity;

    bool isGrounded;
    bool isBoosting;
    int jumpCounter;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        CheckIfGrounded();
        RunForrestRun();
        ProcessJump();

        characterController.Move(velocity * Time.deltaTime);
    }

    void ProcessJump()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Fly();
        }

        if (isGrounded)
        {
            jumpCounter = numberOfJumps;
        }

        if (jumpCounter < 1) { return; }

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
            jumpCounter --;
        }
    }

    void RunForrestRun()
    {
        if (Input.GetKey("d"))
        {
            horizontalSpeed = baseSpeed + boostModifier;
        }
        else
        {
            horizontalSpeed = baseSpeed;
        }
        characterController.Move(new Vector3(horizontalSpeed * Time.deltaTime, 0f, 0f));
    }

    void CheckIfGrounded()
    {
        Vector3 bottomOfCapsule = new Vector3(transform.position.x, transform.position.y - (characterController.height / 2) - .1f, transform.position.z);
        isGrounded = Physics.CheckCapsule(transform.position, bottomOfCapsule, capsuleRadius, groundLayers, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
    }

    void Fly()
    {
        gravity = 0f;
    }
}
