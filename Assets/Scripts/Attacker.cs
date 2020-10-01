using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentMovementSpeed = 2f;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentMovementSpeed);
    }

    public void SetMovementSpeed(float speed)
    {
        currentMovementSpeed = speed;
    }
}
