using UnityEngine;

public class npc_Movement_Platformer : MonoBehaviour {

    public CharacterController2D controller;

    public float runSpeed = 40f;

    private float horizontalMove;
    private bool jump = false;

    private void Update ()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal2")* runSpeed;

        if (Input.GetButtonDown("Jump2"))
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
