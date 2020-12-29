using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Vector3 movement;
    public float speed;
    public float hp;
    private List<Vector3> pathVectorList;
    private int currPathIndex = 0;
    private PathFinding pathFinding;
    private GameObject gridMap;
    public Animator animator;
    [SerializeField] private wolfData wolfData;


    private void Awake()
    {
        gridMap = GameObject.Find("GridMap");
    }
    void Start()
    {
        currPathIndex = 0;
        movement = new Vector3(1.0f, 0.0f, 0f);
        pathFinding = gridMap.GetComponent<gridMap>().pathFinding;
        setTargetPosition(pathFinding.getGrid().getWorldPoss(10, 0));
        initEnemy();
    }

    private void initEnemy()
    {
        speed = wolfData.speed;
        hp = wolfData.hitPoints;
    }
        
    private void Update()
    {

        handleMovement();
        if (hp <= 0)
        {
            killEnemy();
        }
    }
    public void killEnemy()
    {
        Destroy(gameObject);
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
                    killEnemy();
                }
            }
        }
        
        if(movement.x < 0)
        {
            // Multiply the player's x local scale by -1
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        
    }

}
