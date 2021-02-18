using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    Animator animator;
    private void Start()
    {
        slider = GetComponent<Slider>();
        animator = GetComponent<Animator>();
    }

    public void setHealth(int health)
    {
        slider.value = health;
        animator.SetTrigger("TakeDamage");
    }
}
