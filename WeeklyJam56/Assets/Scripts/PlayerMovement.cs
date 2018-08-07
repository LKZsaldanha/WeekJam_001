using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public CharacterController2D controller;

    public float runSpeed = 40f;

    private float horizontalMove;
    private bool jump = false;

    private void Update ()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
	}

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime ,false, jump);
        jump = false;
    }
}
