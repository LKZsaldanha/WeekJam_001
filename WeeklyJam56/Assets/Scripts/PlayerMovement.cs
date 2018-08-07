using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    public bool canMove = true;

    private float horizontalMove;
    private bool jump = false;

    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        controller = FindObjectOfType<CharacterController2D>();
    }

    private void Update ()
    {
        if (gm.allowGameplayInputs)
        {
            if (canMove)
            {
                
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

                animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

                if (Input.GetButtonDown("Jump"))
                {
                    animator.SetBool("IsJumping", true);
                    jump = true;
                }
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

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
