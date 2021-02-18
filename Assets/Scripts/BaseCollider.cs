using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    public HealthBar healthBar;
    int maxHealth = 4;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        TakeDamage();
        Destroy(otherCollider.gameObject);
    }

    private void TakeDamage()
    {
        currentHealth -= 1;
        healthBar.setHealth(currentHealth);
        if (currentHealth <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadGameOverScene();
        }
        
    }
}
