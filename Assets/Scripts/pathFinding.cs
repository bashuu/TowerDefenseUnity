using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.Collections;
using System.IO;



public class PathFinding 
{
    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    private Grid<PathNode> grid;
    private List<PathNode> openList;
    private List<PathNode> closedList;


    public PathFinding(int widht, int height)
    {
        grid = new Grid<PathNode>(widht, height, 2f, (Grid<PathNode>g, int x, int y) => new PathNode(g, x, y));
    }

    public List<PathNode> findPath(int startX, int startY, int endX, int endY)
    {
        PathNode startNode = grid.getGridObject(startX, startY);
        PathNode endNode = grid.getGridObject(endX, endY);

        openList = new List<PathNode>
        {
            startNode
         };
        closedList = new List<PathNode>();

        for (int x = 0; x < grid.widht; x++)
        {
            for (int y = 0; y < grid.height; y++)
            {
                PathNode pathNode = grid.getGridObject(x, y);
                pathNode.gCost = int.MaxValue;
                pathNode.calculateFCost();
                pathNode.cameFromNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDisCost(startNode, endNode);
        startNode.calculateFCost();

        while(openList.Count > 0)
        {
            PathNode currentNode = findLowFCostNode(openList);
            if(currentNode == endNode)
            {
                return calculatePath(endNode);
            }
            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (PathNode neighbourNode in getNeighbourList(currentNode))
            {
                if (closedList.Contains(neighbourNode))
                    continue;

                int tentGCost = currentNode.gCost + CalculateDisCost(currentNode, neighbourNode);

                if(tentGCost < neighbourNode.gCost)
                {
                    neighbourNode.cameFromNode = currentNode;
                    neighbourNode.gCost = tentGCost;
                    neighbourNode.hCost = CalculateDisCost(neighbourNode, endNode);
                    neighbourNode.calculateFCost();

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }

                }
            }
        }

        // out of nodes on the open list

        return null;
    }

    private List<PathNode> getNeighbourList(PathNode currentNode)
    {
        List<PathNode> neighbourList = new List<PathNode>();

        if(currentNode.x - 1 >= 0)
        {
            //left
            neighbourList.Add(getNode(currentNode.x - 1, currentNode.y));
            //left down
            if(currentNode.y - 1 >= 0)
                neighbourList.Add(getNode(currentNode.x - 1, currentNode.y - 1));
            //left up
            if(currentNode.y + 1 < grid.height)
                neighbourList.Add(getNode(currentNode.x - 1, currentNode.y + 1));

        }

        if(currentNode.x + 1 < grid.widht)
        {
            //right
            neighbourList.Add(getNode(currentNode.x + 1, currentNode.y));
            //right down
            if(currentNode.y - 1 >= 0)
                neighbourList.Add(getNode(currentNode.x + 1, currentNode.y - 1));

            //right up
            if(currentNode.y + 1 < grid.height)
                neighbourList.Add(getNode(currentNode.x + 1, currentNode.y + 1));


        }
         //down
         if(currentNode.y - 1 >= 0)
            neighbourList.Add(getNode(currentNode.x, currentNode.y - 1));
         //up
         if(currentNode.y + 1 < grid.height)
            neighbourList.Add(getNode(currentNode.x, currentNode.y + 1));



        return neighbourList;
    }

    private PathNode getNode(int x, int y)
    {
        return grid.getGridObject(x, y);
    }

    public Grid<PathNode> getGrid()
    {
        return grid;
    }

    private List<PathNode> calculatePath(PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        PathNode currentNode = endNode;

        while(currentNode.cameFromNode != null)
        {
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }

        path.Reverse();

        return path;
    }

    private int CalculateDisCost(PathNode a, PathNode b)
    {
        int xDis = Mathf.Abs(a.x - b.x);
        int yDis = Mathf.Abs(a.y - b.y);
        return MOVE_DIAGONAL_COST * Mathf.Min(xDis, yDis) + MOVE_STRAIGHT_COST * Mathf.Abs(xDis - yDis);

    }

    private PathNode findLowFCostNode(List<PathNode> pathNodeList)
    {
        PathNode lowFCostNode = pathNodeList[0];
        for(int i = 0; i < pathNodeList.Count; i++)
        {
            if(pathNodeList[i].fCost < lowFCostNode.fCost)
            {
                lowFCostNode = pathNodeList[i];
            }
        }
        return lowFCostNode;
    }

}
