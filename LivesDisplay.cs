using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    public Image[] hearts;
    public PlayerHealth playerHealth;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = (i < playerHealth.lives);
        }
    }
}
