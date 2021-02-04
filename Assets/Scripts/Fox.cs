using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            if (otherObject.name.Contains("Grave"))
            {
                GetComponent<Animator>().SetTrigger("JumpTrigger");
            } else
            {
                GetComponent<Attacker>().Attack(otherObject);
            }
                
        }
    }
}
