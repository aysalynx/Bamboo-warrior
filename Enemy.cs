using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private bool inRange = false;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Enemy defeated by E");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !Input.GetKey(KeyCode.E))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage();
                Destroy(gameObject);
            }
        }
    }

    
    void OnMouseDown()
    {
        Debug.Log("Clicked on enemy — destroying!");
        Destroy(gameObject);
    }
}
