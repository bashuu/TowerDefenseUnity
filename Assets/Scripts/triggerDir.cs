using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDir : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "Enemy")
        {
            Debug.Log("GameObject2 collided with " + coll.name);
        }
    }
}
