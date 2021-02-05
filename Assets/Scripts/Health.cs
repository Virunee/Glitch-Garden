using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] GameObject deathVFX;
    [Range (0,1)][SerializeField] float deathVolume = 0.3f;
    void Start()
    {
        
    }

    public void DealDamage(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        TriggerDeathVFX();
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathVolume);
        // Add particle VFX effect maybe
    }

    private void TriggerDeathVFX()
    {
        if(!deathVFX)
        {
            return;
        } else
        {
            GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(deathVFXObject, 0.3f);
        }
        
    }
}
