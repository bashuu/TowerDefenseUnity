using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridMap : MonoBehaviour
{
    public Grid<int> grid;
    public int widht = 24;
    public int height = 14;
    public float scale = 1f;
    public PathFinding pathFinding;

    private void Start()
    {
        pathFinding = new PathFinding(widht, height);
    }

    private void Update()
    {
    }
}   
