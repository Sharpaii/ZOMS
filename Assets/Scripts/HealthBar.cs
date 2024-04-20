using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Health playerHealth;
    public TMP_Text textBox;
    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;
        textBox = GetComponentInChildren<TMP_Text>();
    }
    public void SetHealth(int hp)
    {
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = hp;
        textBox.SetText(playerHealth.currentHealth + "/" + playerHealth.maxHealth);
    }
}