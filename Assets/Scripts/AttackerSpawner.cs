﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerArray;

    float difficultyModifier;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        difficultyModifier = PlayerPrefsController.GetDifficulty();
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay - difficultyModifier));
            SpawnAttacker();
        }
        
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        int arrayLength = attackerArray.Length;
        Spawn(Random.Range(0, arrayLength));
        

    }

    private void Spawn(int randomIndex)
    {
        Attacker newAttacker = Instantiate(attackerArray[randomIndex], transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

}
