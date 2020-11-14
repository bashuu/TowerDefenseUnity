using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid 
{

    private int widht;
    private int height;
    public int[,] gridArray;
    public float cellSize;
    public Vector3 offSet;
    public Grid(int widht, int height, float cellSize)
    {
        this.widht = widht;
        this.height = height;
        this.cellSize = cellSize;

        offSet = new Vector3(cellSize, cellSize) * 0.5f;

        gridArray = new int[widht, height];
        for(int x = 0; x < widht; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Debug.DrawLine(getWorldPoss(x, y), getWorldPoss(x + 1, y), Color.white, 100f);
                Debug.DrawLine(getWorldPoss(x, y), getWorldPoss(x, y + 1), Color.white, 100f);
            }
            Debug.DrawLine(getWorldPoss(0, height), getWorldPoss(widht, height), Color.white, 100f);
            Debug.DrawLine(getWorldPoss(widht, 0), getWorldPoss(widht, height), Color.white, 100f);
        }
    }

    public Vector3 getWorldPoss(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    public Vector2Int getXY(Vector3 worldPoss)
    {
        int x = Mathf.FloorToInt(worldPoss.x / cellSize);
        int y = Mathf.FloorToInt(worldPoss.y / cellSize);
        return new Vector2Int(x, y);
    }

    public void setVal(int x, int y, int val)
    {
        if(x >= 0 && y >= 0 && x < widht && y < height)
        {
            gridArray[x, y] = val;
        Debug.Log(x + " " + y + " " + gridArray[x, y]);
        }
    }

    public void setVal(Vector3 worldPoss, int val)
    {
        int x, y;
        x = getXY(worldPoss).x;
        y = getXY(worldPoss).y;
        setVal(x, y, val);

    }

    public int getVal(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < widht && y < height)
            return gridArray[x, y];
        return -1 ;
    }

    public int getVal(Vector3 worldPoss)
    {
        int x, y;
        x = getXY(worldPoss).x;
        y = getXY(worldPoss).y;
        return getVal(x, y);
    }
}
