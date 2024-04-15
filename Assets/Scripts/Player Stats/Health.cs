using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject loseLevelPanel;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        loseLevelPanel.SetActive(false);
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            loseLevelPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void healDamage(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
