using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int goldCost = 100;

    public void AddGold(int amount)
    {
        FindObjectOfType<GoldDisplay>().AddGold(amount);
    }

    public int GetCost()
    {
        return goldCost;
    }
}
