using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerArray;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
        
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
