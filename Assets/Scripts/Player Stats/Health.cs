using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject loseLevelPanel;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        loseLevelPanel.SetActive(false);
    }

    public void takeDamage(int amount)
    {
        if (GetComponent<Collider2D>().enabled == true && player.GetComponent<PlayerMovement>().invincibiliyFrames == 125)
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                loseLevelPanel.SetActive(true);
                Time.timeScale = 0;
            }

            healthBar.SetHealth(currentHealth);
        }
    }

    public void healDamage(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.SetHealth(currentHealth);
    }
}
