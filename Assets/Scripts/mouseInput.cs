using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using UnityEngine;

public class mouseInput : MonoBehaviour
{
    /*
     * 5 = tower;
     * 
     * 
     * 
     * 
     */
    private Vector3 mousePoss;
    public GameObject towerManager;
    public GameObject gridMap;
    private Grid<int> grid;
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
           // if (grid.gridArray[x, y] == 0)
            //{ 
                //towerManager.GetComponent<towerManager>().createTower(grid.getWorldPoss(x, y) + grid.offSet);
               // grid.setGridObject(x, y, 5);
                //Debug.Log(mousePoss);
            //}

            List<PathNode> path = pathFinding.findPath(0, 0, x, y);
            if(path != null)
            {
                for( int i = 0; i < path.Count; i++)
                {
                    Debug.Log(path[i].x + " " + path[i].y);
                }
            }
        }
    }
}
