using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentMovementSpeed = 2f;
    GameObject currentTarget;
    Animator animator;
    float difficultyModifier;

    void Start()
    {
        animator = GetComponent<Animator>();
        difficultyModifier = PlayerPrefsController.GetDifficulty();
    }

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentMovementSpeed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentMovementSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if(!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }
    }
}
