using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth;
    public static int damage = 20;

    public HealthBar healthbar;


    void Start()
    {
        currentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}
