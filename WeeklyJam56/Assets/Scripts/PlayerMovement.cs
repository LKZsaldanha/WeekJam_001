using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public CharacterController2D controller;

    public float runSpeed = 40f;

    private float horizontalMove;
    private bool jump = false;

    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update ()
    {
        if (gm.allowGameplayInputs)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
        else
        {
            horizontalMove = 0;            
        }
	}

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime ,false, jump);
        jump = false;
    }
}
