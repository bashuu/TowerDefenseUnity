using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject enemy;
    private PathFinding pathFinding;
    public float wolfInterval;
    public float wolfSpawnTime;
    public int wolfCount;
    public GameObject gridMap;
    private Vector3 poss;
    [SerializeField] private levelData levelData;
    private void Awake()
    {
        initLevel();
        gridMap = GameObject.Find("GridMap");
    }

    private void Start()
    {
        pathFinding = gridMap.GetComponent<gridMap>().pathFinding;

    }
    void Update()
    {
        
        spawnWolf();
    }

    void initLevel()
    {
        wolfInterval = levelData.wolfInterval;
        wolfSpawnTime = levelData.wolfSpawnTime;
        wolfCount = levelData.wolfCount;

    }
    void spawnWolf()
    {
        wolfSpawnTime -= Time.deltaTime;
        if (wolfSpawnTime <= 0)
        {
            Instantiate(enemy, pathFinding.getGrid().getWorldPoss(0,6) + pathFinding.getGrid().offSet, Quaternion.identity);
            wolfSpawnTime = wolfInterval;
        }
    }
}
