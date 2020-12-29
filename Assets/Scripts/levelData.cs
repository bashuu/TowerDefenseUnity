using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "levelData/level1")]
public class levelData : ScriptableObject
{
    public int wolfCount;
    public float wolfInterval;
    public float wolfSpawnTime;
}
