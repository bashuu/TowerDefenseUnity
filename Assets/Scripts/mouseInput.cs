using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using UnityEngine;

public class mouseInput : MonoBehaviour
{

    private Vector3 mousePoss;
    public GameObject towerManager;
    public GameObject gridMap;
    public GameObject line;

    PathFinding pathFinding;


    private void Awake()
    {
        pathFinding = gridMap.GetComponent<gridMap>().pathFinding;

    }
    void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            if(pathFinding == null)
                pathFinding = gridMap.GetComponent<gridMap>().pathFinding;
            int x, y;
            mousePoss = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePoss2D = new Vector2(mousePoss.x, mousePoss.y);

            x = pathFinding.getGrid().getXY(mousePoss).x;
            y = pathFinding.getGrid().getXY(mousePoss).y;


                if (pathFinding.getGrid().gridArray[x, y].isWalkable)
                {   
                    pathFinding.getGrid().gridArray[x, y].isWalkable = false;
                    List<Vector3> path = pathFinding.findPath(pathFinding.getGrid().getWorldPoss(0, 6), pathFinding.getGrid().getWorldPoss(10, 0));
                    if (path != null)
                        {

                            towerManager.GetComponent<towerManager>().createTower(pathFinding.getGrid().getWorldPoss(x, y) + pathFinding.getGrid().offSet);
                            path = pathFinding.findPath(pathFinding.getGrid().getWorldPoss(0, 6), pathFinding.getGrid().getWorldPoss(10, 0));
                            pathFinding.getGrid().gridArray[x, y].isWalkable = false;
                            line.GetComponent<drawLine>().drawPath(path);
                            //Debug.Log(mousePoss);
                        }
                        else
                        {
                            pathFinding.getGrid().gridArray[x, y].isWalkable = true;
                        }
                }


           
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (pathFinding == null)
                pathFinding = gridMap.GetComponent<gridMap>().pathFinding;
            int x, y;
            mousePoss = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePoss2D = new Vector2(mousePoss.x, mousePoss.y);

            x = pathFinding.getGrid().getXY(mousePoss).x;
            y = pathFinding.getGrid().getXY(mousePoss).y;

            List<PathNode> path = pathFinding.findPath(0, 0, x, y);
            if (path != null)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    Debug.Log(path[i].x + " " + path[i].y);
                }
            }
        }
    }
}
