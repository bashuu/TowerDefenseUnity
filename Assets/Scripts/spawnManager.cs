using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject gridMap;
    private Grid<int> grid; 
    public GameObject enemy;
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
    EnemySpawn enemySpawn;

    private void Start()
    {
    }
    void Update()
    {
        if(grid == null)
        {
            grid = gridMap.GetComponent<gridMap>().grid;
            enemySpawn = new EnemySpawn(2f, 0f, grid.getWorldPoss(0, 13) + grid.offSet);
            Debug.Log(grid);
        }
        else
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
