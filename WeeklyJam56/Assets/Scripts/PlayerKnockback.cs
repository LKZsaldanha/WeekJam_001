using System.Collections;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour {

    public float knockForce = 500f;
    public float xForceMultiplier = 3f;
    public float knockDuration = 1f;

    private Rigidbody2D rb;
    private PlayerMovement pMove;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pMove = GetComponent<PlayerMovement>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {  
        if (collision.gameObject.CompareTag("Spike"))
        {
            CharacterKnockback(collision);
        }
    }

    private IEnumerator CharacterKnockback(Collision2D collision)
    {
        pMove.canMove = false;
        pMove.animator.SetTrigger("IsKnocked");

        Vector2 knockDirection = rb.position - (Vector2)collision.transform.position;
        knockDirection *= knockForce;
        knockDirection.x *= xForceMultiplier;

        rb.AddForce(knockDirection);

        float timer = 0;
        while (knockDuration > timer)
        {
            timer += Time.deltaTime;
        }
        pMove.canMove = true;

        return null;
    }
}
