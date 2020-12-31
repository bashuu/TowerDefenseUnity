using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    private GameObject enemy;
    private GameObject towerType;
    private float towerAttackSpeed;
    private float attackSpeed;
    private int tmp;
    private float towerDamage;
    [SerializeField] private towerData towerData;
    public enum State
    {
        Idle,
        Attack
    }

    public State state;

    private void Start()
    {
        state = State.Idle;
        towerDamage = towerData.towerDamage;
        attackSpeed = towerData.attackSpeed;
        towerAttackSpeed = towerData.towerAttackSpeed;
        towerType = towerData.tower;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Enemy")
        { 
            switch (state){
                case State.Idle:
                    enemy = coll.gameObject;
                    state = State.Attack;
                    break;
                case State.Attack:
                    break;
                default:
                    state = State.Idle;
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            switch (state)
            {
                case State.Idle:
                    break;
                case State.Attack:
                    if (enemy == coll.gameObject)
                    {
                        enemy = null;
                        state = State.Idle;
                    }
                    break;
                default:
                    state = State.Idle;
                    break;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            switch (state)
            {
                case State.Idle:
                    enemy = coll.gameObject;
                    state = State.Attack;
                    break;
                case State.Attack:
                    break;
                default:
                    state = State.Idle;
                    break;
            }
        }
    }

    private void Update()
    {

        switch (state)
        {
            case State.Idle:
                break;
            case State.Attack:
                attackSpeed -= Time.deltaTime;
                if (attackSpeed <= 0)
                {
                    enemy.GetComponent<enemy>().hp -= towerDamage;
                    bulletRayCast.shoot(transform.position, enemy.transform.position);
                    attackSpeed = towerAttackSpeed;
                }

                break;
            default:
                state = State.Idle;
                break;
        }
        if(enemy == null)
        {
            state = State.Idle;
        }

/*        Debug.Log(enemy);
        Debug.Log(state);*/
    }

}
