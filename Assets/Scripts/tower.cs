using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    public GameObject enemy;
    private float towerAttackSpeed = 0.5f;
    private float attackSpeedCD = 0;
    private int tmp;

    public enum State
    {
        Idle,
        Attack
    }

    public State state;

    private void Start()
    {
        state = State.Idle;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Enemy")
        { 
            switch (state){
                case State.Idle:
                    enemy = coll.gameObject;
                    state = State.Idle;
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
        if(enemy == null)
        {
            state = State.Idle;
        }

        switch (state)
        {
            case State.Idle:
                break;
            case State.Attack:
                attackSpeedCD -= Time.deltaTime;
                if (attackSpeedCD <= 0)
                {
                    enemy.GetComponent<enemy>().hp -= 5;
                    attackSpeedCD = towerAttackSpeed;
                }

                break;
            default:
                state = State.Idle;
                break;
        }

        Debug.Log(enemy);
        /*Debug.Log(state);*/
    }
}
