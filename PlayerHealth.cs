using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;

    public void TakeDamage()
    {
        lives--;

        Debug.Log("Lives left: " + lives);

        if (lives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player lost!");
        SceneManager.LoadScene("LoseScreen");
    }
}
