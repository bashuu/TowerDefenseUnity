using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject enemy;
    private PathFinding pathFinding;
    public float interval;
    public float time;
    public GameObject gridMap;
    private Vector3 poss;

    private void Awake()
    {
        gridMap = GameObject.Find("GridMap");
    }

    private void Start()
    {
        pathFinding = gridMap.GetComponent<gridMap>().pathFinding;
    }
    void Update()
    {
        
        spawnEnemy();
    }

    void spawnEnemy()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Instantiate(enemy, pathFinding.getGrid().getWorldPoss(0,6) + pathFinding.getGrid().offSet, Quaternion.identity);
            time = interval;
        }
    }
}
