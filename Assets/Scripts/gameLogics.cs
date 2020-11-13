using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLogics : MonoBehaviour
{
    public int hitPoints = 5;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Enemy")
        {
            hitPoints--;
            Destroy(coll.gameObject);
        }
    }
}
