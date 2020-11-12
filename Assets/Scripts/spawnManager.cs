using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    class EnemySpawn
    {
        public float interval;
        public float time;
        public Vector3 poss;

        public EnemySpawn(float aInterval, float aTime, Vector3 aPoss)
        {
            interval = aInterval;
            time = aTime;
            poss = aPoss;
        }
    }
    public GameObject enemy;
    EnemySpawn enemySpawn;

    private void Start()
    {
        enemySpawn = new EnemySpawn(2f, 0f, new Vector3(-10f, 4, 0));
    }
    void Update()
    {
        spawnEnemy();
    }

    void spawnEnemy()
    {
        enemySpawn.time -= Time.deltaTime;
        if (enemySpawn.time <= 0)
        {
            Instantiate(enemy, enemySpawn.poss, Quaternion.identity);
            enemySpawn.time = enemySpawn.interval;
        }
    }
}
