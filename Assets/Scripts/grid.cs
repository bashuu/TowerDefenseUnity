using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

public class Grid<TGridObject>
{

    public int widht;
    public int height;
    public TGridObject[,] gridArray;
    public float cellSize;
    public Vector3 offSet;
    public Grid(int widht, int height, float cellSize, Func<Grid<TGridObject>,int, int, TGridObject> creatGridObject)
    {
        this.widht = widht;
        this.height = height;
        this.cellSize = cellSize;

        offSet = new Vector3(cellSize, cellSize) * 0.5f;

        gridArray = new TGridObject[widht, height];
        for (int x = 0; x < widht; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gridArray[x, y] = creatGridObject(this, x, y);
                //createWorldText(null, x.ToString() + " - " + y.ToString(), getWorldPoss(x, y) + offSet, 10, Color.white, TextAnchor.MiddleCenter);
                //Debug.DrawLine(getWorldPoss(x, y), getWorldPoss(x + 1, y), Color.white, 100f);
                //Debug.DrawLine(getWorldPoss(x, y), getWorldPoss(x, y + 1), Color.white, 100f);
            }
            //Debug.DrawLine(getWorldPoss(0, height), getWorldPoss(widht, height), Color.white, 100f);
            //Debug.DrawLine(getWorldPoss(widht, 0), getWorldPoss(widht, height), Color.white, 100f);
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

    public void setGridObject(int x, int y, TGridObject val)
    {
        if (x >= 0 && y >= 0 && x < widht && y < height)
        {
            gridArray[x, y] = val;
            Debug.Log(x + " " + y + " " + gridArray[x, y]);
        }
    }

    public void setGridObject(Vector3 worldPoss, TGridObject val)
    {
        int x, y;
        x = getXY(worldPoss).x;
        y = getXY(worldPoss).y;
        setGridObject(x, y, val);

    }

    public TGridObject getGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < widht && y < height)
            return gridArray[x, y];
        return default(TGridObject);
    }

    public TGridObject getGridObject(Vector3 worldPoss)
    {
        int x, y;
        x = getXY(worldPoss).x;
        y = getXY(worldPoss).y;
        return getGridObject(x, y);
    }


    private static TextMesh createWorldText(Transform parent, string text, Vector3 localPoss, int fontSize, Color color, TextAnchor textAnchor)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transfrom = gameObject.transform;
        transfrom.SetParent(parent, false);
        transfrom.localPosition = localPoss;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        //textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        //textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }


}
