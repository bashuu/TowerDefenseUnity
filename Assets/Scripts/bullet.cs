using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damage;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            coll.GetComponent<enemy>().hp -= damage;
            Destroy(gameObject);
        }
    }
}
