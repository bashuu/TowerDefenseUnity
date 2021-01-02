using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "levelData/level1")]
public class levelData : ScriptableObject
{
    public int wolfCount;
    public float wolfInterval;
    public float wolfSpawnTime;

    public int panthionCount;
    public float panthionInterval;
    public float panthionSpawnTime;

    
    public int warriorCount;
    public float warriorInterval;
    public float warriorSpawnTime;

    public Vector2Int gridSpawnPosition;

    public GameObject wolf;
    public GameObject panthion;
    public GameObject warrior;
}
