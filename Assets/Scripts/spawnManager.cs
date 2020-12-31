using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    private GameObject wolf;
    private GameObject panthion;
    private GameObject warrior;

    private PathFinding pathFinding;

    private float wolfInterval;
    private float wolfSpawnTime;
    public int wolfCount;

    private float panthionInterval;
    private float panthionSpawnTime;
    public int panthionCount;

    private float warriorInterval;
    private float warriorSpawnTime;
    public int warriorCount;

    public int roundNumber;
    public GameObject gridMap;
    private bool roundStart = false;
    
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
        handleRound();
    }

    private void initLevel()
    {
        wolfInterval = levelData.wolfInterval;
        wolfSpawnTime = levelData.wolfSpawnTime;
        wolfCount = levelData.wolfCount;
        wolf = levelData.wolf;

        panthionInterval = levelData.panthionInterval;
        panthionSpawnTime = levelData.panthionSpawnTime;
        panthionCount = levelData.panthionCount;
        panthion = levelData.panthion;

        warriorInterval = levelData.warriorInterval;
        warriorSpawnTime = levelData.warriorSpawnTime;
        warriorCount = levelData.warriorCount;
        warrior = levelData.warrior;
    }
    private void spawnWolf()
    {
        wolfSpawnTime -= Time.deltaTime;
        if (wolfSpawnTime <= 0)
        {
            Instantiate(wolf, pathFinding.getGrid().getWorldPoss(0,6) + pathFinding.getGrid().offSet, Quaternion.identity);
            wolfCount--;
            wolfSpawnTime = wolfInterval;
        }
    }

    private void spawnPanthion()
    {
        panthionSpawnTime -= Time.deltaTime;
        if (panthionSpawnTime <= 0)
        {
            Instantiate(panthion, pathFinding.getGrid().getWorldPoss(0, 6) + pathFinding.getGrid().offSet, Quaternion.identity);
            panthionCount--;
            panthionSpawnTime = panthionInterval;
        }
    }

    private void spawnWarrior()
    {
        warriorSpawnTime -= Time.deltaTime;
        if (warriorSpawnTime <= 0)
        {
            Instantiate(warrior, pathFinding.getGrid().getWorldPoss(0, 6) + pathFinding.getGrid().offSet, Quaternion.identity);
            warriorCount--;
            warriorSpawnTime = warriorInterval;
        }
    }

    private void spawnEnemy()
    {
        if(wolfCount > 0)
        {
            spawnWolf();
            spawnPanthion();
        }
        if (panthionCount > 0)
        {
            spawnPanthion();
        }

        if (warriorCount > 0)
        {
            spawnWarrior();
        }
    }

    void handleRound()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
            roundStart = true;
        }
        if (roundStart)
        {
            spawnEnemy();
        }
    }

    private void endRound()
    {

    }

}
