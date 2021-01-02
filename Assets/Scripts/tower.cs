using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class tower : MonoBehaviour
{
    private GameObject enemy;
    public GameObject bullet;
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
                    /* enemy.GetComponent<enemy>().hp -= towerDamage;
                     bulletRayCast.shoot(transform.position, enemy.transform.position);*/
                    initBullet();
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

    private void initBullet()
    {
        GameObject newBullet;

        Vector2 direction = enemy.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        newBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, angle) );
        newBullet.GetComponent<bullet>().damage = towerDamage;
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * 20f;
    }
}
