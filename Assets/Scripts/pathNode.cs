using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.Collections;
using System.IO;

public class PathNode
{

    private Grid<PathNode> grid;
    public int x;
    public int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode cameFromNode;
    public bool isWalkable;

    public PathNode(Grid<PathNode> grid, int x, int y)
    {
        //this.grid = grid;
        this.x = x;
        this.y = y;
        isWalkable = true;
    }

    public void calculateFCost()
    {
        fCost = gCost + fCost;
    }

}
