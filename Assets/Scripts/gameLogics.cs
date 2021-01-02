using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class gameLogics : MonoBehaviour
{
    private GameObject wolf;
    private GameObject panthion;
    private GameObject warrior;

    private PathFinding pathFinding;

    private float wolfInterval;
    private float wolfSpawnTime;
    private int wolfCount;

    private float panthionInterval;
    private float panthionSpawnTime;
    private int panthionCount;

    private float warriorInterval;
    private float warriorSpawnTime;
    private int warriorCount;

    private Vector2Int gridSpawnPosition;

    public int roundNumber = 1;
    private GameObject gridMap;
    [SerializeField] public GameObject tower;
    [SerializeField] private levelData levelData;
    [SerializeField] private mouseInput mouseInput;

    public enum State
    {
        Defend,
        Build
    }

    public State state;
    private void Awake()
    {
        initLevel();
        gridMap = GameObject.Find("GridMap");
    }

    private void Start()
    {
        pathFinding = gridMap.GetComponent<gridMap>().pathFinding;
        state = State.Build;

    }
    void Update()
    {

        switch (state)
        {
            case State.Build:
                 if (Input.GetKeyDown("space"))
                 { 
                     state = State.Defend;
                 }
                break;
            case State.Defend:
                spawnEnemy();
                break;

            default:
                state = State.Build;
                break;
        }
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

        gridSpawnPosition = levelData.gridSpawnPosition;
    }
    private void spawnWolf()
    {
        wolfSpawnTime -= Time.deltaTime;
        if (wolfSpawnTime <= 0)
        {
            Instantiate(wolf, pathFinding.getGrid().getWorldPoss(gridSpawnPosition.x, gridSpawnPosition.y) + pathFinding.getGrid().offSet, Quaternion.identity);
            wolfCount--;
            wolfSpawnTime = wolfInterval;
        }
    }

    private void spawnPanthion()
    {
        panthionSpawnTime -= Time.deltaTime;
        if (panthionSpawnTime <= 0)
        {
            Instantiate(panthion, pathFinding.getGrid().getWorldPoss(gridSpawnPosition.x, gridSpawnPosition.y) + pathFinding.getGrid().offSet, Quaternion.identity);
            panthionCount--;
            panthionSpawnTime = panthionInterval;
        }
    }

    private void spawnWarrior()
    {
        warriorSpawnTime -= Time.deltaTime;
        if (warriorSpawnTime <= 0)
        {
            Instantiate(warrior, pathFinding.getGrid().getWorldPoss(gridSpawnPosition.x, gridSpawnPosition.y) + pathFinding.getGrid().offSet, Quaternion.identity);
            warriorCount--;
            warriorSpawnTime = warriorInterval;
        }
    }

    private void spawnEnemy()
    {
        bool check = true;
        if(wolfCount > 0)
        {
            spawnWolf();
            check = false;
        }
        if (panthionCount > 0)
        {
            spawnPanthion();
            check = false;
        }

        if (warriorCount > 0)
        {
            spawnWarrior();
            check = false;
        }

        if (check)
        {
            endRound();
        }

    }

    private void endRound()
    {
        state = State.Build;
        roundNumber++;
    }

    public void createTower(Vector3 poss)
    {
        poss.z = 0;
        if(state == State.Build)
            Instantiate(tower, poss, Quaternion.identity);
    }

}
