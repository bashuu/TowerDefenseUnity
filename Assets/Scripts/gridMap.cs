using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridMap : MonoBehaviour
{
    public int widht;
    public int height;
    public PathFinding pathFinding;
    public float scale;


    private void Awake()
    {
        pathFinding = new PathFinding(widht, height);
    

    }

    private void Update()
    {
    }


}   
