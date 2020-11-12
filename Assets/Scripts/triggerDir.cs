using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDir : MonoBehaviour
{
    [SerializeField]
    public enum Dir {up, down, right, left};


    public Dir dir;
    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "Enemy")
        {
            switch (dir)
            {
                case Dir.down:
                    coll.gameObject.GetComponent<enemy>().movement = new Vector2(0f, -1f);
                    break;
                case Dir.up:
                    coll.gameObject.GetComponent<enemy>().movement = new Vector2(0f, 1f);
                    break;
                case Dir.right:
                    coll.gameObject.GetComponent<enemy>().movement = new Vector2(1f, 0f);
                    break;
                case Dir.left:
                    coll.gameObject.GetComponent<enemy>().movement = new Vector2(-1f, 0f);
                    break;
                default:
                    coll.gameObject.GetComponent<enemy>().movement = new Vector2(1f, 0f);
                    break;
            }
            //Debug.Log("GameObject2 collided with " + coll.name);
        }
    }
}
