using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerManager : MonoBehaviour
{
    public GameObject tower;
    public towerData towerData;



    public void createTower(Vector3 poss)
    {
        poss.z = 0;
        Instantiate(tower, poss, Quaternion.identity);
    }

}
