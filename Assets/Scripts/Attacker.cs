using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentMovementSpeed = 2f;
    GameObject currentTarget;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentMovementSpeed);
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
}
