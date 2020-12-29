using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletRayCast
{
    public static void shoot(Vector3 shootPoss, Vector3 shootDir)
    {
        RaycastHit2D hit =  Physics2D.Raycast(shootPoss, shootDir);

        if (hit.collider != null)
        {
            //hit
            Debug.DrawLine(shootPoss, shootDir);
        }
    }
}
