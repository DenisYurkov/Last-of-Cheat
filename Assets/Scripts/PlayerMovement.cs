using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController playerController;

    [SerializeField] float speedMove = 12f;
    [SerializeField] float gravity = -9.81f;

    [SerializeField] Transform gravityCheck;
    [SerializeField] float gravityDistance = 0.4f;
    [SerializeField] LayerMask gravityMask;

    [SerializeField] float jumpHeight = 3f; 

    Vector3 velocuty;
    bool isGrounded;
    
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(gravityCheck.position, gravityDistance, gravityMask);

        if (isGrounded && velocuty.y < 0)
        {
            velocuty.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        playerController.Move(move * speedMove * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocuty.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocuty.y += gravity * Time.deltaTime;

        // s = 1/2 * g * t2 - Free fall formula.
        playerController.Move(velocuty * Time.deltaTime);
    }
}
