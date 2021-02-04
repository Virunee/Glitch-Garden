using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] int gold = 350;
    Text goldText;
    // Start is called before the first frame update
    void Start()
    {
        goldText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        goldText.text = gold.ToString();
    }

    public int GetGoldAmount()
    {
        return gold;
    }

    public bool HaveEnoughGold(int amount)
    {
        return gold >= amount;
    }

    public void AddGold(int amountToAdd)
    {
        gold += amountToAdd;
        UpdateDisplay();
    }

    public void SpendGold(int amountToSpend)
    {
        if(gold >= amountToSpend)
        {
            gold -= amountToSpend;
            UpdateDisplay();
        }
    }
}
