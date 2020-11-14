using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridMap : MonoBehaviour
{
    private Vector3 mousePoss;
    public Grid grid;
    public GameObject tower;

    private void Start()
    {
        grid = new Grid(22, 14, 1f);
        
    }

    private void Update()
    {
    }
}   
