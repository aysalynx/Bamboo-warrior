using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 8f;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            anim.SetBool("IsJumping", true);
        }

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            float detectRadius = 4f;
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectRadius);

            foreach (var hit in hits)
            {
                if (hit.CompareTag("Enemy"))
                {
                    Destroy(hit.gameObject);
                    Debug.Log("Destroy enemy on E");
                    break;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("IsJumping", false);
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}
