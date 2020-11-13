using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Vector2 movement;
    public float speed = 10f;
    public int hp = 50;
    void Start()
    {
        movement = new Vector2(1.0f, 0.0f);
    }
        
    private void Update()
    {
        transform.Translate(movement * Time.deltaTime * speed);

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
        //Debug.Log("testing");
    }

}
