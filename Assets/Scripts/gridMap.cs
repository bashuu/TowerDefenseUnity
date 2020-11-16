using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridMap : MonoBehaviour
{
    public Grid<int> grid;
    public int widht;
    public int height;
    public float scale;
    public PathFinding pathFinding;

    private void Awake()
    {
        pathFinding = new PathFinding(widht, height);
    }

    private void Update()
    {
    }
}   
