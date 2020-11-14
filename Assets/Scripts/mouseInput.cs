using System.Collections;
using System.Collections.Generic;
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
    private Grid grid;

    private void Start()
    {
        grid = gridMap.GetComponent<gridMap>().grid;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int x, y;
            mousePoss = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePoss2D = new Vector2(mousePoss.x, mousePoss.y);

            x = grid.getXY(mousePoss).x;
            y = grid.getXY(mousePoss).y;
            if(grid.gridArray[x, y] == 0)
            { 
                towerManager.GetComponent<towerManager>().createTower(grid.getWorldPoss(x, y) + grid.offSet);
                grid.setVal(x, y, 5);
                //Debug.Log(mousePoss);
            }
        }
    }
}
