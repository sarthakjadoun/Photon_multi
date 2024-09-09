using Fusion;
using UnityEngine;
using UnityEditor;

public class Playermove : NetworkBehaviour
{
    private Vector3 velocity;
    private bool jumpPressed;

    private CharacterController controller;

    public float PlayerSpeed = 2f;

    public float JumpForce = 5f;
    public float GravityValue = -9.81f;

    public Camera Camera;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }

    public override void Spawned()
    {
        if(HasStateAuthority)
        {
            Camera = Camera.main;
            Camera.GetComponent<Cameramove>().target = transform;
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority == false)
        {
            return;
        }

        if (controller.isGrounded)
        {
            velocity = new Vector3(0, -1, 0);
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Runner.DeltaTime * PlayerSpeed;


        velocity.y += GravityValue * Runner.DeltaTime;

        if (jumpPressed && controller.isGrounded)
        {
            velocity.y += JumpForce;
        }

        controller.Move(move + velocity * Runner.DeltaTime);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        jumpPressed = false;
    }
}