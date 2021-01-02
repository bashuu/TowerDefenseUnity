using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour
{
    public LineRenderer line;
    private List<Vector3> pathVectorList;
    private PathFinding pathFinding;
    private GameObject gridMap;
    private void Awake()
    {
        gridMap = GameObject.Find("GridMap");
    }

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        pathFinding = gridMap.GetComponent<gridMap>().pathFinding;
        pathVectorList = pathFinding.findPath(pathFinding.getGrid().getWorldPoss(0, 6), pathFinding.getGrid().getWorldPoss(10, 0));
        drawPath(pathVectorList);

    }

    public void createLine(float x, float y, int indexCount) 
    {
        line.SetPosition(indexCount, new Vector3(x, y, 0));
    }

    public void drawPath(List<Vector3> pathVectorList)
    {
        int currPathIndex = 0;
        line.positionCount = pathVectorList.Count;
        while (currPathIndex < pathVectorList.Count)
        {
            line.SetPosition(currPathIndex, pathVectorList[currPathIndex]);
            currPathIndex++;
        }

    }
}
