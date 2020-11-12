using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseInput : MonoBehaviour
{
    private Vector3 mousePoss;
    public GameObject towerManager;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePoss = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            towerManager.GetComponent<towerManager>().createTower(mousePoss);
            Debug.Log(mousePoss);
        }
    }
}
