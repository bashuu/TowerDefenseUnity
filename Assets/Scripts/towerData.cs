using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "TowerData/tower")]
public class towerData : ScriptableObject
{
    public float towerAttackSpeed = 0.5f;
    public float attackSpeed= 0.1f;
    public float towerDamage = 0;
    public GameObject tower;
}
