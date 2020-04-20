using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EnemySpawn
{
    public GameObject enemy;
    public float spawnChance;
}

public partial class EnemySpawner : MonoBehaviour
{
    public EnemySpawn[] enemyTypes;
    public float spawnTimer = 6;
    private float spawnTimerCD;
    private float spawnChanceSum = 0;

    // Start is called before the first frame update
    void Start_S()
    {
        spawnTimerCD = spawnTimer;
        //Get sum of all enemies' spawn chance
        for (int i = 0; i < enemyTypes.Length; i++)
        {
            spawnChanceSum += enemyTypes[i].spawnChance;
        }

        //Sort enemy array by spawn chance
        EnemySpawn temp;
        for (int write = 0; write < enemyTypes.Length; write++)
        {
            for (int sort = 0; sort < enemyTypes.Length - 1; sort++)
            {
                if (enemyTypes[sort].spawnChance > enemyTypes[sort + 1].spawnChance)
                {
                    temp = enemyTypes[sort + 1];
                    enemyTypes[sort + 1] = enemyTypes[sort];
                    enemyTypes[sort] = temp;
                }
            }
        }
    }

    // Update is called once per frame
    void Update_S()
    {
        spawnTimerCD -= Time.deltaTime;
        if (spawnTimerCD < 0)
        {
            spawnTimerCD = spawnTimer;
            float chance = Random.Range(0, spawnChanceSum);
            for (int i = 0; i < enemyTypes.Length; i++)
            {
                if (chance <= enemyTypes[i].spawnChance)
                {
                    //print(enemyTypes[i].enemy.name + " has been spawned");
                    Instantiate(enemyTypes[i].enemy, new Vector3(12, 0, 2), gameObject.transform.rotation);
                }
                else
                {
                    chance += enemyTypes[i].spawnChance;
                }
            }
        }
    }
}
