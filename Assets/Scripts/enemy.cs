using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Vector3 movement;
    public float speed = 10f;
    public int hp = 50;
    private List<Vector3> pathVectorList;
    private int currPathIndex = 0;
    private PathFinding pathFinding;
    private GameObject gridMap;

    private void Awake()
    {
        gridMap = GameObject.Find("GridMap");
    }
    void Start()
    {
        currPathIndex = 0;
        movement = new Vector3(1.0f, 0.0f, 0f);
        pathFinding = gridMap.GetComponent<gridMap>().pathFinding;
        Debug.Log(pathFinding);
        setTargetPosition(pathFinding.getGrid().getWorldPoss(10, 0));
    }
        
    private void Update()
    {

        handleMovement();

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void  setTargetPosition(Vector3 targetPosition)
    {
        currPathIndex = 0;
        pathVectorList = pathFinding.findPath(transform.position, targetPosition);

        if(pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
        
    }

    public void handleMovement()
    {
        if (pathVectorList != null)
        {
            Vector3 targetPoss = pathVectorList[currPathIndex];
            if (Vector3.Distance(transform.position, targetPoss) > 0.1f)
            {
                movement = (targetPoss - transform.position).normalized;
                float disBefore = Vector3.Distance(transform.position, targetPoss);
                transform.position = transform.position + movement * speed * Time.deltaTime;
            }
            else
            {
                currPathIndex++;
                if (currPathIndex >= pathVectorList.Count)
                {
                    pathVectorList = null;
                }
            }
        }
   
        
    }

}
