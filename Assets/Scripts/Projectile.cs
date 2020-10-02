using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 100;
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Attacker>() && collision.GetComponent<Health>())
        {
            Health health = collision.GetComponent<Health>();
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
